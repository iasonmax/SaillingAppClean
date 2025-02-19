namespace SailingAppClean.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IShipRepository Ship { get; }

        void Save();
    }
}
