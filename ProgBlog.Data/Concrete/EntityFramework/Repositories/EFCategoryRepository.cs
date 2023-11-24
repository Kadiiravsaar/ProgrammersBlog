using Microsoft.EntityFrameworkCore;
using ProgBlog.Data.Abstract;
using ProgBlog.Entites.Concrete;
using ProgBlog.Shared.Data.Concrete.EntityFramework;

namespace ProgBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EFCategoryRepository : EfEntityRepositoryBase<Category>, ICategoryRepository
    {
        public EFCategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
