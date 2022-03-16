using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystemAppWebAPI.Controllers
{
    public class StudentMarksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
