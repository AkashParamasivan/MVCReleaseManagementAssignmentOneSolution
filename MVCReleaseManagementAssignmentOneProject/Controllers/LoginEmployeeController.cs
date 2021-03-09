using MVCReleaseManagementAssignmentOneProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCReleaseManagementAssignmentOneProject.Controllers
{
    public class LoginEmployeeController : Controller
    {
        ReleaseManagementContext releaseManagementContext = new ReleaseManagementContext();
        // GET: LoginEmployee
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginDetails loginDetails)
        {
            try
            {
                var user = releaseManagementContext.RegisterEmployeesProp.Single(u => u.Username == loginDetails.Username && u.Password == loginDetails.Password);
                if (user != null)
                {
                    if(user.Role == "Manager")
                    {
                        return RedirectToAction("Navigate", "Manager");
                    }
                    if(user.Role == "Teamlead")
                    {
                        return RedirectToAction("TeamleadNavigate", "Teamlead");
                    }
                    if(user.Role == "Developer")
                    {
                        TempData["developerId"] = user.EmployeeId;
                        return RedirectToAction("DeveloperNavigate", "Developer");
                    }
                    if(user.Role == "Tester")
                    {
                        TempData["testerId"] = user.EmployeeId;
                        return RedirectToAction("TesterNavigate", "Tester");
                    }
                }
            }
            catch
            {
                ViewBag.Message = "User Not Found !! Please Enter the correct Username and Password !!";
            }
            return View();
        }
    }
}