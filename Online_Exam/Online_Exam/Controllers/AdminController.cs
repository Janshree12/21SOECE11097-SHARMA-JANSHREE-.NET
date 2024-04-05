using Microsoft.AspNetCore.Mvc;
using Online_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam.Controllers
{
    public class AdminController : Controller
    {
       

        Groups empObj = new Groups();
        User obj = new User();
        public IActionResult Index()
        {
           empObj = new Groups();
            List<Groups> lst = empObj.getData();// fetches all the records
            return View(lst);
        }
        public IActionResult Users()
        {
            return View(Index);
        }
        public IActionResult Students()
        {
            return View();
        }
        [HttpGet]
        public IActionResult NewGroupLogin()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult NewGroupLogin(Groups emp)
        {
            bool res;
            if (ModelState.IsValid)
            {
                Groups empObj = new Groups();
                res = empObj.insert(emp);
                if (res)
                {
                    TempData["msg"] = "Added successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["msg"] = "Not Added. something went wrong..!!";
                }
            }
            return View();
        }

        public IActionResult AdminLogin()
        {

            return View();
        }
        public IActionResult CreateStudent()
        {
            return View();
        }

        public IActionResult CreateTeacher()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateTeacher(User emp)
        {
            bool res;
            if (ModelState.IsValid)
            {
                User empobj = new User();
                res = empobj.insert(emp);
                if (res)
                {
                    TempData["msg"] = "Added successfully";
                }
                else
                {
                    TempData["msg"] = "Not Added. something went wrong..!!";
                }
            }
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        

    }
}
