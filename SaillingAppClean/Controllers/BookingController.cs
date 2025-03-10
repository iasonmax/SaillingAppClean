using Microsoft.AspNetCore.Mvc;
using SailingAppClean.Application.Common.Interfaces;
using SailingAppClean.Domain.Entities;

namespace SaillingAppClean.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult FinalizeBooking(int shipId, DateOnly checkInDate, DateOnly checkOutDate)
        {
            Booking booking = new()
            {
                ShipId = shipId,
                Ship = _unitOfWork.Ship.Get(u => u.Id == shipId, includeProperties: "Category"),
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                Nights = checkOutDate.DayNumber - checkInDate.DayNumber
            };

            booking.TotalCost = booking.Ship.BaseDailyRate * booking.Nights;

            return View(booking);
        }
    }
}
