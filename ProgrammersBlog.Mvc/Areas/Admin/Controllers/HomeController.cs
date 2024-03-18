using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Mvc.Models;
using System.Diagnostics;

namespace ProgrammersBlog.Mvc.Areas.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

       
      
    }
}
