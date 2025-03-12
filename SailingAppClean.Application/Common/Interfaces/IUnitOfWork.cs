namespace SailingAppClean.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IShipRepository Ship { get; }
        ICategoryRepository Category { get; }
        IBookingRepository Booking { get; }
        IApplicationUserRepository User { get; }

        void Save();
    }
}
