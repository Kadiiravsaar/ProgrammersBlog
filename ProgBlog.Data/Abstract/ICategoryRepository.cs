using ProgBlog.Entites.Concrete;
using ProgBlog.Shared.Data.Abstract;

namespace ProgBlog.Data.Abstract
{
    public interface ICategoryRepository : IEntityRepository<Category>
    {
    }
}
