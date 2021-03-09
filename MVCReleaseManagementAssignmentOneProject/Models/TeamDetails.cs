using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCReleaseManagementAssignmentOneProject.Models
{
    public class TeamDetails
    {
        public TeamDetails()
        {

        }
        public TeamDetails(string teamId,string teamName,int availabilityStatus,string projectId,string teamleadId,string developerId,string testerId)
        {
            TeamId = teamId;
            TeamName = teamName;
            AvailabilityStatus = availabilityStatus;
            ProjectId = projectId;
            TeamleadId = teamleadId;
            DeveloperId = developerId;
            TesterId = testerId;
        }
        [Key]
        [Required]
        public string TeamId { get; set; }
        [Required]
        public string TeamName { get; set; }
        [Required]
        public int AvailabilityStatus { get; set; }
        [Required]
        public string ProjectId { get; set; }
        [Required]

        public string TeamleadId { get; set; }
        [Required]
        public string DeveloperId { get; set; }
        [Required]
        public string TesterId { get; set; }
        [Required]


        [ForeignKey("ProjectId")]
        public ProjectDetails Project { get; set; }
        [Required]
        [ForeignKey("TeamleadId")]
        public TeamleadDetails Teamlead { get; set; }
        [Required]
        [ForeignKey("DeveloperId")]
        public DeveloperDetails Developer { get; set; }
        [Required]
        [ForeignKey("TesterId")]
        public TesterDetails Tester { get; set; }
    }
}