using AutoMapper;
using ProgrammersBlog.Entites.Concrete;
using ProgrammersBlog.Entites.Dtos.ArticleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.AutoMapper.Profiles
{
    public class ArticleProfile:Profile
    {
        public ArticleProfile()
        {
            // adddto içinde createdDate yok ancak bunu aşağıdaki gibi yapacağız


            // ArticleAddDto al ve article'ye dönüştür
            CreateMap<ArticleAddDto, Article>().ForMember(dest=>dest.CreatedDate,opt=>opt.MapFrom(x=>DateTime.UtcNow)); 
            CreateMap<ArticleUpdateDto, Article>().ForMember(dest => dest.ModifiedByName, opt => opt.MapFrom(x => DateTime.UtcNow));
        }


    }
}
