using SailingAppClean.Domain.Entities;

namespace SailingAppClean.Application.Common.Utility
{
    public static class SD
    {
        public const string Role_Admin = "Admin";
        public const string Role_Skipper = "Skipper";
        public const string Role_Customer = "Customer";


        public const string Status_Pending = "Pending";
        public const string Status_Approved = "Approved";
        public const string Status_CheckedIn = "CheckedIn";
        public const string Status_Completed = "Completed";
        public const string Status_Canceled = "Canceled";
        public const string Status_Refunded = "Refunded";

        public static bool ShipsAvailiability(int shipId,
            DateOnly checkInDate, DateOnly checkOutDate, List<Booking> bookings)
        {
            foreach (var booking in bookings)
            {
                if (checkInDate < booking.CheckOutDate && checkOutDate > booking.CheckInDate && booking.ShipId == shipId)
                    return false;
            }
            return true;
        }
    }
}
