using MVCReleaseManagementAssignmentOneProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCReleaseManagementAssignmentOneProject.Controllers
{
    public class DeveloperController : Controller
    {
        ReleaseManagementContext releaseManagementContext = new ReleaseManagementContext();
        
        // GET: Developer
        public ActionResult DeveloperNavigate()
        {
            string developerId = TempData.Peek("developerId").ToString();
            TempData["developerIdToUPS"] = developerId;
            TempData["developerIdToVM"] = developerId;
            TempData["developerIdToVB"] = developerId;
            return View();
        }
        public ActionResult UpdateProjectStatus()
        {
            
            string developerIdOfUPS = TempData.Peek("developerIdToUPS").ToString();
            var projectModule = from pro in releaseManagementContext.AddProjectProp
                                join mod in releaseManagementContext.ModuleDetailsProp
                                on pro.ProjectId equals
                                mod.ProjectId
                                into modPro
                                from mp in modPro.DefaultIfEmpty()
                                select new
                                {
                                    pro.ProjectId,
                                    pro.ProjectName,
                                    pro.ProjectStatus,
                                    mp.DeveloperId
                                };
            var devlist = projectModule.Where(a => a.DeveloperId == developerIdOfUPS && a.ProjectStatus != 1);
            ViewBag.ddl = new SelectList(devlist, "ProjectId", "ProjectId");
            return View();
        }
        [HttpPost]
        public ActionResult UpdateProjectStatus(ProjectDetails projectDetails)
        {
            string developerIdOfUPS = TempData.Peek("developerIdToUPS").ToString();
            var projectModule = from pro in releaseManagementContext.AddProjectProp
                                join mod in releaseManagementContext.ModuleDetailsProp
                                on pro.ProjectId equals
                                mod.ProjectId
                                into modPro
                                from mp in modPro.DefaultIfEmpty()
                                select new
                                {
                                    pro.ProjectId,
                                    pro.ProjectName,
                                    pro.ProjectStatus,
                                    mp.DeveloperId
                                };
            var devlist = projectModule.Where(a => a.DeveloperId == developerIdOfUPS && a.ProjectStatus != 1);
            ViewBag.ddl = new SelectList(devlist, "ProjectId", "ProjectId");
            try
            {
                var projectquery = releaseManagementContext.AddProjectProp.Single(m => m.ProjectId == projectDetails.ProjectId);
                ViewBag.MessageOne = projectquery.ProjectName;
                projectquery.ProjectStatus = projectDetails.ProjectStatus;
                releaseManagementContext.SaveChanges();
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "Please select an option" + e.Message;
            }
            return View();
        }
        public ActionResult ViewModulesDeveloper()
        {
            string developerIdOfVM = TempData.Peek("developerIdToVM").ToString();
            var moduleData = releaseManagementContext.ModuleDetailsProp.Where(u => u.DeveloperId == developerIdOfVM).ToList();
            return View(moduleData);
        }
        public ActionResult ViewBugsDeveloper()
        {
            string developerIdOfVB = TempData.Peek("developerIdToVB").ToString();
            var bugData = releaseManagementContext.BugsDetailsProp.Where(u => u.DeveloperId == developerIdOfVB).ToList();
            return View(bugData);
        }
    }
}