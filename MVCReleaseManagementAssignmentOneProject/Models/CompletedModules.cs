using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCReleaseManagementAssignmentOneProject.Models
{
    public class CompletedModules
    {
        public CompletedModules()
        {

        }
        public CompletedModules(string moduleApprovalId,string moduleId,string teamleadModuleApprovalStatus,string managerModuleApprovalStatus)
        {
            ModuleApprovalId = moduleApprovalId;
            ModuleId = moduleId;
            TeamleadModuleApprovalStatus = teamleadModuleApprovalStatus;
            ManagerModuleApprovalStatus = managerModuleApprovalStatus;
        }
        [Key]
        [Required]
        public string ModuleApprovalId { get; set; }
        [Required]
        public string ModuleId { get; set; }
        [Required]
        
        public string TeamleadModuleApprovalStatus { get; set; }
        [Required]
        public string ManagerModuleApprovalStatus { get; set; }
        [ForeignKey("ModuleId")]
        [Required]
        public ModuleDetails Module { get; set;  }

    }
}