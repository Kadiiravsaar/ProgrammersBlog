using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entites.Concrete;
using ProgrammersBlog.Shared.Data.Concrete.EntityFramework;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EFCategoryRepository : EfEntityRepositoryBase<Category>, ICategoryRepository
    {
        public EFCategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
