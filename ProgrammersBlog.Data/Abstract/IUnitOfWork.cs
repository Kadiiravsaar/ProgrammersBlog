namespace ProgrammersBlog.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IArticleRepository Articles { get; } // unitOfWork.Articles
        ICategoryRepository Categories { get; } // unitOfWork.Categories
        ICommentRepository Comments { get; } // unitOfWork.Comments
        IUserRepository Users { get; } // unitOfWork.Users
        IRoleRepository Roles { get; } // unitOfWork.Users

        Task<int> SaveAsync(); // etkilenen kayıt sayılarını almak istersem diye <int>

        // unitOfWork.Users.AddAsync(user);
        // unitOfWork.Categories.AddAsync(category);
        // unitOfWork.SaveAsync();
    }
}
