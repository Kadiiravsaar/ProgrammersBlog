using ProgrammersBlog.Entites.Concrete;
using ProgrammersBlog.Shared.Data.Abstract;

namespace ProgrammersBlog.Data.Abstract
{
    public interface IUserRepository : IEntityRepository<User>
    {
    }
}
