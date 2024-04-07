using ProgrammersBlog.Entities.Dtos.CategoryDto;
using ProgrammersBlog.Entities.Dtos.UserDto;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class UserAddAjaxViewModel
    {
        public UserDto UserDto { get; set; }
        public UserAddDto UserAddDto { get; set; }
        public string UserAddPartial { get; set; }
    }
}
