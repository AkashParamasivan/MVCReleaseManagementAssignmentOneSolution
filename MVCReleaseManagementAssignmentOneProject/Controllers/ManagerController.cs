using MVCReleaseManagementAssignmentOneProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCReleaseManagementAssignmentOneProject.Controllers
{
    public class ManagerController : Controller
    {
        ReleaseManagementContext releaseManagementContext = new ReleaseManagementContext();
        // GET: Manager

        public ActionResult Navigate()
        {
            return View();
        }
        public ActionResult AddProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(ProjectDetails projectDetails)
        {
            try
            {
                releaseManagementContext.AddProjectProp.Add(projectDetails);
                releaseManagementContext.SaveChanges();                        
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }
      public ActionResult ApproveModule()
        {
            var ddl = releaseManagementContext.CompletedModulesProp.Where(model => model.ManagerModuleApprovalStatus != "Approved").ToList();
            ViewBag.ddl = new SelectList(ddl, "ModuleApprovalId", "ModuleApprovalId");
            return View();
        }
        [HttpPost]
        public ActionResult ApproveModule(CompletedModules completedModules)
        {
            var ddl = releaseManagementContext.CompletedModulesProp.Where(model => model.ManagerModuleApprovalStatus != "Approved").ToList();
            ViewBag.ddl = new SelectList(ddl, "ModuleApprovalId", "ModuleApprovalId");
            try
            {
                var user = releaseManagementContext.CompletedModulesProp.Single(m => m.ModuleApprovalId == completedModules.ModuleApprovalId);
                ViewBag.MessageOne = user.ModuleId;
                ViewBag.MessageTwo = user.TeamleadModuleApprovalStatus;
                user.ManagerModuleApprovalStatus = completedModules.ManagerModuleApprovalStatus;
                releaseManagementContext.SaveChanges();
            }
            catch(Exception e)
            {
                ViewBag.ErrorMessage = "Please select an option" + e.Message;
            }

            return View();
        }
        public ActionResult ApproveProject()
        {
            var ddl = releaseManagementContext.CompletedProjectsProp.Where(model => model.ProjectApprovalStatus != "Approved").ToList();
            ViewBag.ddl = new SelectList(ddl, "ProjectApprovalId", "ProjectApprovalId");
            return View();
        }
        [HttpPost]
        public ActionResult ApproveProject(CompletedProjects completedProjects)
        {
            var ddl = releaseManagementContext.CompletedProjectsProp.Where(model => model.ProjectApprovalStatus != "Approved").ToList();
            ViewBag.ddl = new SelectList(ddl, "ProjectApprovalId", "ProjectApprovalId");
            try
            {
                var user = releaseManagementContext.CompletedProjectsProp.Single(m => m.ProjectApprovalId == completedProjects.ProjectApprovalId);
                ViewBag.MessageOne = user.ProjectId;
                user.ProjectApprovalStatus = completedProjects.ProjectApprovalStatus;
                releaseManagementContext.SaveChanges();
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "Please select an option" + e.Message;
            }

            return View();
        }
    }
}