using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCReleaseManagementAssignmentOneProject.Models
{
    public class CompletedProjects
    {
        public CompletedProjects()
        {

        }
        public CompletedProjects(string projectApprovalId, string projectId, string projectApprovalStatus)
        {
            ProjectApprovalId = projectApprovalId;
            ProjectId = projectId;
            ProjectApprovalStatus = projectApprovalStatus;
        }
        [Key]
        [Required]
        public string ProjectApprovalId { get; set; }
        [Required]
        public string ProjectId { get; set; }
        [Required]
        public string ProjectApprovalStatus { get; set; }
        [ForeignKey("ProjectId")]
        [Required]
        public ProjectDetails Project { get; set; }
    }
}