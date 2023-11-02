using ProgBlog.Entites.Concrete;
using ProgBlog.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgBlog.Data.Abstract
{
    public interface IArticleRepository : IEntityRepository<Article>
    {
    }
}
