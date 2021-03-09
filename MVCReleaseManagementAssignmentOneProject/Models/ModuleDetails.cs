using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCReleaseManagementAssignmentOneProject.Models
{
    public class ModuleDetails
    {
        public ModuleDetails()
        {

        }
        public ModuleDetails(string moduleId,int moduleStatus,string projectId,string developerId,string testerId)
        {
            ModuleId = moduleId;
            ModuleStatus = moduleStatus;
            ProjectId = projectId;
            DeveloperId = developerId;
            TesterId = testerId;
        }
        [Key]
        [Required]
        public string ModuleId { get; set; }
        [Required]
        public int ModuleStatus { get; set; }
        [Required]
        public string ProjectId { get; set; }
        [Required]
        public string DeveloperId { get; set; }
        [Required]
        public string TesterId { get; set; }
        [Required]
        [ForeignKey("ProjectId")]
        public ProjectDetails Project { get; set; }
        [Required]
        [ForeignKey("DeveloperId")]
        public DeveloperDetails Developer { get; set; }
        [Required]
        [ForeignKey("TesterId")]
        public TesterDetails Tester { get; set; }
    }
}