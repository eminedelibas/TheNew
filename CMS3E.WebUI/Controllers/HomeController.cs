using System.Linq;
using CMS.Data.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository repository)
        {
            _employeeRepository = repository;
        }

        //public IActionResult HomePage()
        //{
        //    return View();
        //}

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        //public IActionResult Admin()
        //{
        //    return View();
        //}
        //[Authorize(Roles = "User")]
        //public IActionResult UserPage()
        //{
        //    return View();
        //}
        
    }
}