namespace SailingAppClean.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IShipRepository Ship { get; }
        ICategoryRepository Category { get; }

        void Save();
    }
}
