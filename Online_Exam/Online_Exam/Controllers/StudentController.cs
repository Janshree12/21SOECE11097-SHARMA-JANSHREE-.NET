using Microsoft.AspNetCore.Mvc;

namespace Online_Exam.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Result()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult StudentLogin()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

    }
}
