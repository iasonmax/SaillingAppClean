using SailingAppClean.Application.Common.Interfaces;
using SailingAppClean.Domain.Entities;
using SaillingAppClean.Infrastructure.Data;
using SaillingAppClean.Infrastructure.Repository;

namespace SaillingAppClean.Infrastructure.Repositories
{
    internal class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }
    }
}
