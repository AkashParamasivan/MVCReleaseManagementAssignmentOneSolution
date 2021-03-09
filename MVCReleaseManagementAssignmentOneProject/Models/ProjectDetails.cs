using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCReleaseManagementAssignmentOneProject.Models
{
    public class ProjectDetails
    {
        public ProjectDetails()
        {

        }

        public ProjectDetails(string projectId,string projectName,string projectRequirements,DateTime expectedStartDate,DateTime expectedEndDate,DateTime actualStartDate,DateTime actualEndDate,int projectStatus)
        {
            ProjectId = projectId;
            ProjectName = projectName;
            ProjectRequirements = projectRequirements;
            ExpectedStartDate = expectedStartDate;
            ExpectedEndDate = expectedEndDate;
            ActualStartDate = actualStartDate;
            ActualEndDate = actualEndDate;
            ProjectStatus = projectStatus;
        }

        [Key]
        [Required]
        public string ProjectId { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public string ProjectRequirements { get; set; }
        [Required]
        public DateTime ExpectedStartDate { get; set; }
        [Required]
        public DateTime ExpectedEndDate { get; set; }
        [Required]
        public DateTime ActualStartDate { get; set; }
        [Required]
        public DateTime ActualEndDate { get; set; }
        [Required]
        public int ProjectStatus { get; set; }
    }
}