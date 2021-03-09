using MVCReleaseManagementAssignmentOneProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCReleaseManagementAssignmentOneProject.Controllers
{
    public class TesterController : Controller
    {
        // GET: Tester
        ReleaseManagementContext releaseManagementContext = new ReleaseManagementContext();

        public ActionResult TesterNavigate()
        {
            string testerIdOfTN = TempData.Peek("testerId").ToString();
            TempData["testerIdToUBS"] = testerIdOfTN;
            TempData["testerIdToVM"] = testerIdOfTN;
            TempData["testerIdToVB"] = testerIdOfTN;
            return View();
        }
        public ActionResult RaiseBug()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RaiseBug(BugsDetails bugsDetails)
        {
            releaseManagementContext.BugsDetailsProp.Add(bugsDetails);
            releaseManagementContext.SaveChanges();
            return View();
        }
        public ActionResult UpdateBugStatus()
        {
            string testerIdOfUBS = TempData.Peek("testerIdToUBS").ToString();
            var ddl = releaseManagementContext.BugsDetailsProp.Where(model => model.TesterId == testerIdOfUBS && model.BugStatus != 1).ToList();
            ViewBag.ddl = new SelectList(ddl, "BugId", "BugId");
            return View();
        }
        [HttpPost]
        public ActionResult UpdateBugStatus(BugsDetails bugs)
        {
            string testerIdOfUBS = TempData.Peek("testerIdToUBS").ToString();
            var ddl = releaseManagementContext.BugsDetailsProp.Where(model => model.TesterId == testerIdOfUBS && model.BugStatus != 1).ToList();
            ViewBag.ddl = new SelectList(ddl, "BugId", "BugId");
            try
            {
                var bugsQuery = releaseManagementContext.BugsDetailsProp.Single(m => m.BugId == bugs.BugId);
                ViewBag.MessageOne = bugsQuery.ModuleId;
                bugsQuery.BugStatus = bugs.BugStatus;
                releaseManagementContext.SaveChanges();
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "Please select an option" + e.Message;
            }
            return View();
        }
        public ActionResult ViewTesterModules()
        {
            string testerIdOfVM = TempData.Peek("testerIdToVM").ToString();
            var viewmoduledata = releaseManagementContext.ModuleDetailsProp.Where(t => t.TesterId == testerIdOfVM).ToList();
            return View(viewmoduledata);
        }

        public ActionResult ViewTesterBugs()
        {
            string testerIdOfVB = TempData.Peek("testerIdToVB").ToString();
            var viewbugdata = releaseManagementContext.BugsDetailsProp.Where(t => t.TesterId == testerIdOfVB).ToList();
            return View(viewbugdata);
        }

    }
}