using SailingAppClean.Application.Common.Interfaces;
using SailingAppClean.Domain.Entities;
using SaillingAppClean.Infrastructure.Data;

namespace SaillingAppClean.Infrastructure.Repository
{
    internal class ShipRepository : Repository<Ship>, IShipRepository
    {
        private readonly ApplicationDbContext _db;
        public ShipRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Ship ship)
        {
            _db.Ships.Update(ship);
        }
    }
}
