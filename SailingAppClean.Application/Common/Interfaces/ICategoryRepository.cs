using SailingAppClean.Domain.Entities;

namespace SailingAppClean.Application.Common.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public void Update(Category category);
    }
}
