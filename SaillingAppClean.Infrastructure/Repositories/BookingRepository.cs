using SailingAppClean.Application.Common.Interfaces;
using SailingAppClean.Application.Common.Utility;
using SailingAppClean.Domain.Entities;
using SaillingAppClean.Infrastructure.Data;
using SaillingAppClean.Infrastructure.Repository;

namespace SaillingAppClean.Infrastructure.Repositories
{
    internal class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationDbContext db) : base(db)
        {
        }

        public void Update(Booking booking)
        {
            _db.Bookings.Update(booking);
        }

        public void UpdateStatus(int bookingId, string bookingStatus)
        {
            var bookingFromDB = _db.Bookings.FirstOrDefault(u => u.Id == bookingId);
            if (bookingFromDB != null)
            {
                bookingFromDB.Status = bookingStatus;
                if (bookingStatus == SD.Status_CheckedIn)
                    bookingFromDB.ActualCheckInDate = DateTime.Now;
                if (bookingStatus == SD.Status_Completed)
                    bookingFromDB.ActualCheckOutDate = DateTime.Now;
            }
        }

        public void UpdateStripePaymentID(int bookingId, string sessionId, string paymentIntentId)
        {
            var bookingFromDb = _db.Bookings.FirstOrDefault(u => u.Id == bookingId);
            if (bookingFromDb != null)
            {
                bookingFromDb.StripeSessionId = sessionId;
            }
            if (!string.IsNullOrEmpty(paymentIntentId))
            {
                bookingFromDb.StripePaymentIntentId = paymentIntentId;
                bookingFromDb.PaymentDate = DateTime.Now;
                bookingFromDb.IsPaymentSuccessfull = true;
            }
        }
    }
}
