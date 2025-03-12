using SailingAppClean.Application.Common.Interfaces;
using SaillingAppClean.Infrastructure.Data;
using SaillingAppClean.Infrastructure.Repositories;

namespace SaillingAppClean.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IShipRepository Ship { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public IBookingRepository Booking { get; private set; }
        public IApplicationUserRepository User { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Ship = new ShipRepository(_db);
            Category = new CategoryRepository(_db);
            Booking = new BookingRepository(_db);
            User = new ApplicationUserRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
