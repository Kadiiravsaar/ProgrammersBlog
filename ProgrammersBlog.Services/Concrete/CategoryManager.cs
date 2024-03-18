using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entites.Concrete;
using ProgrammersBlog.Entites.Dtos.CategoryDto;
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
        private readonly IMapper _mapper;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            var category = _mapper.Map<Category>(categoryAddDto);
            category.CreatedByName = createdByName;
            category.ModifiedByName = createdByName;

            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, message: $"{categoryAddDto.Name} kategorisi eklendi");
        }
        public async Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string updatedByName)
        {

            var category = _mapper.Map<Category>(categoryUpdateDto);
            category.ModifiedByName = updatedByName;
            await _unitOfWork.Categories.UpdateAsync(category).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, message: $"{categoryUpdateDto.Name} kategorisi güncellendi");
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

        public async Task<IDataResult<CategoryDto>> Get(int categoryId)
        {

            //var category = await _unitOfWork.Categories.GetAsyncEng(
            //         predicate: c => c.Id == categoryId, 
            //         include: c => c.Include(c => c.Articles));  // Dene bunu

            var category = await _unitOfWork.Categories.GetAsync(
                    predicate: c => c.Id == categoryId,
                    includeProperties: c => c.Articles);

            if (category != null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, data: new CategoryDto()
                {
                    Category = category,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, message: "Böyle bir kategori bulunamadı", data: null);

        }
        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(predicate: null, includeProperties: c => c.Articles);

            //var categories = await _unitOfWork.Categories.GetListAsync(predicate: null, include: c => c.Include(c => c.Articles));  // bunu da dene


            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, data: new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });

            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, message: "Hiç kategori bulunamadı", data: null);


        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDelete()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(predicate: c => !c.IsDeleted, includeProperties: c => c.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, data: new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });

            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, message: "Hiç kategori bulunamadı", data: null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeleteAndActive()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(predicate: c => !c.IsDeleted && c.IsActive, includeProperties: c => c.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, data: new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });

            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, message: "Hiç kategori bulunamadı", data: null);
        }
    }
}
