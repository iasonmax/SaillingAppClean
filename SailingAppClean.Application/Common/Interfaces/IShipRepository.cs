using SailingAppClean.Domain.Entities;

namespace SailingAppClean.Application.Common.Interfaces
{
    public interface IShipRepository : IRepository<Ship>
    {
        public void Update(Ship ship);
    }
}
