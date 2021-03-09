using MVCReleaseManagementAssignmentOneProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCReleaseManagementAssignmentOneProject.Controllers
{
    public class RegisterEmployeeController : Controller
    {
        ReleaseManagementContext releaseManagementContext = new ReleaseManagementContext();
        // GET: RegisterEmployee
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(EmployeeDetails registerEmployee)
        {
            try
            {
                releaseManagementContext.RegisterEmployeesProp.Add(registerEmployee);
                releaseManagementContext.SaveChanges();
                var user = releaseManagementContext.RegisterEmployeesProp.Single(u => u.EmployeeId == registerEmployee.EmployeeId);
                 if(user.Role == "Teamlead")
                {
                    TeamleadDetails teamleadDetails = new TeamleadDetails(user.EmployeeId, user.EmployeeName);
                    releaseManagementContext.TeamleadDetailsProp.Add(teamleadDetails);
                    releaseManagementContext.SaveChanges();
                }
                 if(user.Role == "Developer")
                {
                    DeveloperDetails developerDetails = new DeveloperDetails(user.EmployeeId, user.EmployeeName);
                    releaseManagementContext.DeveloperDetailsProp.Add(developerDetails);
                    releaseManagementContext.SaveChanges();
                }
                if(user.Role == "Tester")
                {
                    TesterDetails testerDetails = new TesterDetails(user.EmployeeId, user.EmployeeName);
                    releaseManagementContext.TesterDetailsProp.Add(testerDetails);
                    releaseManagementContext.SaveChanges();
                }
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }
    }
}