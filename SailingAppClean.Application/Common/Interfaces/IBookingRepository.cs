using SailingAppClean.Domain.Entities;

namespace SailingAppClean.Application.Common.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        public void Update(Booking booking);
    }
}
