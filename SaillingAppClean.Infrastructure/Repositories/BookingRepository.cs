using SailingAppClean.Application.Common.Interfaces;
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
            throw new NotImplementedException();
        }
    }
}
