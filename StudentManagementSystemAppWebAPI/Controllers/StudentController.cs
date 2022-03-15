using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystemAppWebAPI.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
