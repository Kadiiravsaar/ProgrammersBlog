using AutoMapper;
using ProgrammersBlog.Entites.Concrete;
using ProgrammersBlog.Entites.Dtos.CategoryDto;

namespace ProgrammersBlog.Services.AutoMapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            // adddto içinde createdDate yok ancak bunu aşağıdaki gibi yapacağız


            // CategoryAddDto al ve Category'ye dönüştür
            CreateMap<CategoryAddDto, Category>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.UtcNow));
            CreateMap<CategoryUpdateDto, Category>().ForMember(dest => dest.ModifiedByName, opt => opt.MapFrom(x => DateTime.UtcNow));
        }


    }
}
