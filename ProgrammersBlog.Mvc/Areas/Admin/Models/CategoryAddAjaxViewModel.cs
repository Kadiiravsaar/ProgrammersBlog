using ProgrammersBlog.Entities.Dtos.CategoryDto;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class CategoryAddAjaxViewModel
    {
        public CategoryDto CategoryDto { get; set; }
        public CategoryAddDto CategoryAddDto { get; set; }
        public string CategoryAddPartial { get; set; }
    }
}
