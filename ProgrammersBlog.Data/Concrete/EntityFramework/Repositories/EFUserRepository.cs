using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Concrete.EntityFramework;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EFUserRepository : EfEntityRepositoryBase<User>, IUserRepository
    {
        public EFUserRepository(DbContext context) : base(context)
        {
        }
    }
}
