using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SailingAppClean.Application.Common.Interfaces;
using SailingAppClean.Application.Common.Utility;
using SailingAppClean.Domain.Entities;
using Stripe.Checkout;
using System.Security.Claims;

namespace SaillingAppClean.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult FinalizeBooking(int shipId, DateOnly checkInDate, DateOnly checkOutDate)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ApplicationUser user = _unitOfWork.User.Get(u => u.Id == userId);
            Booking booking = new()
            {
                ShipId = shipId,
                Ship = _unitOfWork.Ship.Get(u => u.Id == shipId, includeProperties: "Category"),
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                Nights = checkOutDate.DayNumber - checkInDate.DayNumber,
                UserId = userId,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Name = user.Name

            };

            booking.TotalCost = booking.Ship.BaseDailyRate * booking.Nights;

            return View(booking);
        }

        [Authorize]
        [HttpPost]
        public IActionResult FinalizeBooking(Booking booking)
        {
            Ship ship = _unitOfWork.Ship.Get(u => u.Id == booking.ShipId);
            booking.TotalCost = ship.BaseDailyRate * booking.Nights;

            booking.Status = SD.Status_Pending;
            booking.BookingTime = DateTime.Now;

            var bookings = _unitOfWork.Booking.GetAll(u => u.Status == SD.Status_Approved || u.Status == SD.Status_CheckedIn, includeProperties: "Ship").ToList();
            ship.IsAvailiable = SD.ShipsAvailiability(ship.Id, booking.CheckInDate, booking.CheckOutDate, bookings);

            if (!ship.IsAvailiable)
            {
                TempData["error"] = "Ship has been booked";
                return RedirectToAction(nameof(FinalizeBooking), new
                {
                    shipId = booking.ShipId,
                    checkInDate = booking.CheckInDate,
                    nights = booking.Nights
                });
            }



            _unitOfWork.Booking.Add(booking);
            _unitOfWork.Save();

            var domain = Request.Scheme + "://" + Request.Host.Value + "/";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                SuccessUrl = domain + $"booking/BookingConfirmation?bookingId={booking.Id}",
                CancelUrl = domain + $"booking/FinalizeBooking?shipId={booking.ShipId}&checkInDate={booking.CheckInDate}&checkOutDate={booking.CheckOutDate}",
            };

            options.LineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = (long)(booking.TotalCost * 100),
                    Currency = "gbp",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = ship.Name,
                    }

                },
                Quantity = 1
            });

            var service = new SessionService();
            Session session = service.Create(options);

            _unitOfWork.Booking.UpdateStripePaymentID(booking.Id, session.Id, session.PaymentIntentId);
            _unitOfWork.Save();
            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }

        [Authorize]
        public IActionResult BookingConfirmation(int bookingId)
        {
            Booking bookingFromDB = _unitOfWork.Booking.Get(u => u.Id == bookingId,
                includeProperties: "User,Ship");

            if (bookingFromDB.Status == SD.Status_Pending)
            {
                var service = new SessionService();
                Session session = service.Get(bookingFromDB.StripeSessionId);
                if (session.PaymentStatus == "paid")
                {
                    _unitOfWork.Booking.UpdateStatus(bookingFromDB.Id, SD.Status_Approved);
                    _unitOfWork.Booking.UpdateStripePaymentID(bookingFromDB.Id, session.Id, session.PaymentIntentId);
                    _unitOfWork.Save();
                }

            }
            return View(bookingId);

        }

        [Authorize]
        [HttpPost]
        public IActionResult CheckIn(Booking booking)
        {
            _unitOfWork.Booking.UpdateStatus(booking.Id, SD.Status_CheckedIn);
            _unitOfWork.Save();
            TempData["Success"] = "Booking Updated Successfully.";
            return RedirectToAction(nameof(BookingDetails), new { bookingId = booking.Id });
        }

        [Authorize]
        [HttpPost]
        public IActionResult CheckOut(Booking booking)
        {
            _unitOfWork.Booking.UpdateStatus(booking.Id, SD.Status_Completed);
            _unitOfWork.Save();
            TempData["Success"] = "Booking Completed Successfully.";
            return RedirectToAction(nameof(BookingDetails), new { bookingId = booking.Id });
        }

        [Authorize]
        [HttpPost]
        public IActionResult CancelBooking(Booking booking)
        {
            _unitOfWork.Booking.UpdateStatus(booking.Id, SD.Status_Canceled);
            _unitOfWork.Save();
            TempData["Success"] = "Booking Canceled Successfully.";
            return RedirectToAction(nameof(BookingDetails), new { bookingId = booking.Id });
        }

        [Authorize]
        public IActionResult BookingDetails(int bookingId)
        {
            Booking bookingFromDb = _unitOfWork.Booking.Get(u => u.Id == bookingId,
                includeProperties: "User,Ship,Ship.Category");

            return View(bookingFromDb);
        }
        #region API CALLS
        [HttpGet]
        [Authorize]
        public IActionResult GetAll(string status)
        {
            IEnumerable<Booking> bookings;

            if (User.IsInRole(SD.Role_Admin))
            {
                bookings = _unitOfWork.Booking.GetAll(includeProperties: "User,Ship");
            }
            else
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                bookings = _unitOfWork.Booking
                    .GetAll(u => u.UserId == userId, includeProperties: "User,Ship");
            }
            if (!string.IsNullOrEmpty(status))
            {
                bookings = bookings.Where(u => u.Status.ToLower().Equals(status.ToLower()));
            }
            return Json(new { data = bookings });
        }

        #endregion

    }
}
