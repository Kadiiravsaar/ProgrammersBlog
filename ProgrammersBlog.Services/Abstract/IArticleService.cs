using ProgrammersBlog.Entites.Dtos.ArticleDto;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;

namespace ProgrammersBlog.Services.Abstract
{
    public interface IArticleService
    {
        Task<IDataResult<ArticleDto>> Get(int articleId);
        Task<IDataResult<ArticleListDto>> GetAll();
        Task<IDataResult<ArticleListDto>> GetAllByNonDeleted(); // Silinmemiş olanları getirelim
        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive(); // Hem silinmemiş Hem de aktif olan makaleleri getirelim
        Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId); // Kategoriye göre makaleleri getir
        Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName);
        Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName);
        Task<IResult> Delete(int articleId, string modifiedByName);
        Task<IResult> HardDelete(int articleId);
    }

}
