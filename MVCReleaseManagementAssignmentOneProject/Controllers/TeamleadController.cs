using MVCReleaseManagementAssignmentOneProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCReleaseManagementAssignmentOneProject.Controllers
{
    public class TeamleadController : Controller
    {
        ReleaseManagementContext db = new ReleaseManagementContext();
        // GET: Teamlead
        public ActionResult TeamleadNavigate()
        {
            return View();
        }
        public ActionResult AddToModule()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddToModule(ModuleDetails addmodule)
        {
            try
            {
                db.ModuleDetailsProp.Add(addmodule);
                ViewBag.message = "Added Module Successfully!";
                db.SaveChanges();


            }
            catch (Exception e)
            {
                ViewBag.message = e.Message;
               
            }
            return View();
        }
        
        
        public ActionResult ViewStatus()
        {

            var statusdata = db.ModuleDetailsProp.ToList();
            return View(statusdata);
        }

        public ActionResult TeamleadApproveModule()
        {

            var ddl = db.CompletedModulesProp.Where(model => model.ManagerModuleApprovalStatus != "Approved").ToList();
            ViewBag.ddl = new SelectList(ddl, "ModuleApprovalId", "ModuleApprovalId");
            return View();
        }
        [HttpPost]
        public ActionResult TeamleadApproveModule(CompletedModules completedModules)
        {
            var ddl = db.CompletedModulesProp.Where(model => model.ManagerModuleApprovalStatus != "Approved").ToList();
            ViewBag.ddl = new SelectList(ddl, "ModuleApprovalId", "ModuleApprovalId");
            try
            {
                var user = db.CompletedModulesProp.Single(m => m.ModuleApprovalId == completedModules.ModuleApprovalId);
                ViewBag.MessageOne = user.ModuleId;
                user.TeamleadModuleApprovalStatus = completedModules.TeamleadModuleApprovalStatus;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "Please select an option" + e.Message;
            }

            return View();
        }



    }
}