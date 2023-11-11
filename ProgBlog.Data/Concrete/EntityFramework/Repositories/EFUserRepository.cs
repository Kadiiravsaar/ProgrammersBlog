using Microsoft.EntityFrameworkCore;
using ProgBlog.Data.Abstract;
using ProgBlog.Entites.Concrete;
using ProgBlog.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EFUserRepository : EfEntityRepositoryBase<User>, IUserRepository
    {
        public EFUserRepository(DbContext context) : base(context)
        {
        }
    }
}
