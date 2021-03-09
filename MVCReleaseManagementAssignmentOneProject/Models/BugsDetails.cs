using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCReleaseManagementAssignmentOneProject.Models
{
    public class BugsDetails
    {
        public BugsDetails()
        {

        }
        public BugsDetails(string bugId,int bugStatus,string moduleId,string testerId)
        {
            BugId = bugId;
            BugStatus = bugStatus;
            ModuleId = moduleId;
            TesterId = testerId;
        }
        [Key]

        [Required]
        public string BugId { get; set; }
        [Required]
        public int BugStatus { get; set; }
        [Required]
        public string ModuleId { get; set; }
        public string DeveloperId { get; set; }
        [Required]
        public string TesterId { get; set; }
        [ForeignKey("ModuleId")]
        [Required]
        public ModuleDetails Module { get; set; }
        [ForeignKey("DeveloperId")]
        [Required]
        public DeveloperDetails Developer { get; set; }
        [ForeignKey("TesterId")]
        [Required]
        public TesterDetails Tester { get; set; }
    }
}