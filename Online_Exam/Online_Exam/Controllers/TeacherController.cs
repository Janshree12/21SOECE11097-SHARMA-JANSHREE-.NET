using Microsoft.AspNetCore.Mvc;
using Online_Exam.Models;

namespace Online_Exam.Controllers
{
    public class TeacherController : Controller
    {
       
        public IActionResult Index()
        {
           return View();
        }
        
        public IActionResult NewExam()
        {
           
            return View();
        }
        public IActionResult QueAns()
        {
            return View();
        }
        public IActionResult QnA()
        {
            return View();
        }
        public IActionResult TeacherLogin()
        {
            return View();
        }
    }
}
