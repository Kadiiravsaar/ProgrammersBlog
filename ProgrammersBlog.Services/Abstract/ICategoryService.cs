using ProgrammersBlog.Entites.Concrete;
using ProgrammersBlog.Entites.Dtos.CategoryDto;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryListDto>> GetAll(); // Tüm kategorileri getiren metot

        Task<IDataResult<CategoryListDto>> GetAllByNonDelete(); // Silinmemiş olan tüm kategorileri getiren metot

        Task<IDataResult<CategoryListDto>> GetAllByNonDeleteAndActive(); // Hem Silinmemiş hem aktif olan tüm kategorileri getiren metot


        Task<IDataResult<CategoryDto>> Get(int categoryId); // Belirli bir kategoriyi id'ye göre getiren metot

        Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName); // Yeni bir kategori ekleyen metot

        Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string updatedByName); // Varolan bir kategoriyi güncelleyen metot

        Task<IResult> Delete(int categoryId, string modifiedByName); // Belirli bir kategoriyi silen metot
        Task<IResult> HardDelete(int categoryId); // Db'den silmek için 

    }
}
