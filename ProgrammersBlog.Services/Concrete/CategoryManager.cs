using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entites.Concrete;
using ProgrammersBlog.Entites.Dtos.Category;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {

        private readonly IUnitOfWork _unitOfWork;
        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            await _unitOfWork.Categories.AddAsync(entity: new Category
            {
                Name = categoryAddDto.Name,
                Description = categoryAddDto.Description,
                IsActive = categoryAddDto.IsActive,
                Note = categoryAddDto.Note,
                CreatedByName = createdByName,
                ModifiedByName = createdByName,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                IsDeleted = false
            });
         

            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success,message:$"{categoryAddDto.Name} kategorisi eklendi");
        }
        public async Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string updatedByName)
        {
            var categoryId = await _unitOfWork.Categories.GetAsync(predicate: c => c.Id == categoryUpdateDto.Id);
            if (categoryId != null)
            {
                categoryId.Name = categoryUpdateDto.Name;
                categoryId.Description = categoryUpdateDto.Description;
                categoryId.Note = categoryUpdateDto.Note;
                categoryId.IsActive = categoryUpdateDto.IsActive;
                categoryId.IsDeleted = categoryUpdateDto.IsDeleted;

                categoryId.ModifiedByName = updatedByName;
                categoryId.ModifiedDate = DateTime.UtcNow;
                await _unitOfWork.Categories.UpdateAsync(categoryId).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, message: $"{categoryUpdateDto.Name} kategorisi güncellendi");

            }

            return new Result(ResultStatus.Error, message: "Böyle bir kategori bulunamadı");

        }

        public async Task<IResult> Delete(int categoryId, string modifiedByName)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                category.IsDeleted = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                await _unitOfWork.Categories.UpdateAsync(category).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{category.Name} adlı kategori başarıyla silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle bir kategori bulunamadı.");
        }

        public async Task<IResult> HardDelete(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                await _unitOfWork.Categories.DeleteAsync(category).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{category.Name} adlı kategori başarıyla veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle bir kategori bulunamadı.");
        }

        public async Task<IDataResult<Category>> Get(int categoryId)
        {

            //var category = await _unitOfWork.Categories.GetAsyncEng(
            //         predicate: c => c.Id == categoryId, 
            //         include: c => c.Include(c => c.Articles));  // Dene bunu

            var category = await _unitOfWork.Categories.GetAsync(
                    predicate: c => c.Id == categoryId,
                    includeProperties: c => c.Articles);

            if (category != null)
            {
                return new DataResult<Category>(ResultStatus.Success, data: category);
            }
            return new DataResult<Category>(ResultStatus.Error, message: "Böyle bir kategori bulunamadı", data: null);

        }
        public async Task<IDataResult<IList<Category>>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(predicate: null, includeProperties: c => c.Articles);

            //var categories = await _unitOfWork.Categories.GetListAsync(predicate: null, include: c => c.Include(c => c.Articles));  // bunu da dene


            if (categories.Count > -1)
            {
                return new DataResult<IList<Category>>(ResultStatus.Success, data: categories);

            }
            return new DataResult<IList<Category>>(ResultStatus.Error, message: "Hiç kategori bulunamadı", data: null);


        }

        public async Task<IDataResult<IList<Category>>> GetAllByNonDelete()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(predicate: c => !c.IsDeleted, includeProperties: c => c.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<IList<Category>>(ResultStatus.Success, data: categories);

            }
            return new DataResult<IList<Category>>(ResultStatus.Error, message: "Hiç kategori bulunamadı", data: null);
        }

   

       

       
    }
}
