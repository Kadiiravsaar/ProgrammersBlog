using Microsoft.EntityFrameworkCore;
using ProgBlog.Data.Abstract;
using ProgBlog.Entites.Concrete;
using ProgBlog.Shared.Data.Concrete.EntityFramework;

namespace ProgBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EFCommentRepository : EfEntityRepositoryBase<Comment>, ICommentRepository
    {
        public EFCommentRepository(DbContext context) : base(context)
        {
        }
    }
}
