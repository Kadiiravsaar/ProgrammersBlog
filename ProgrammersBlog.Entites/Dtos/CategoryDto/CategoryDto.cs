using ProgrammersBlog.Entites.Concrete;
using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entites.Dtos.CategoryDto
{
    public class CategoryDto : DtoGetBase
    {
        public Category Category{ get; set; }
    }
}
