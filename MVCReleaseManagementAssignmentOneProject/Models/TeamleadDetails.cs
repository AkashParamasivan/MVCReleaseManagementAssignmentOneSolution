using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCReleaseManagementAssignmentOneProject.Models
{
    public class TeamleadDetails
    {
        public TeamleadDetails()
        {

        }
        public TeamleadDetails(string teamleadId,string teamleadName)
        {
            TeamleadId = teamleadId;
            TeamleadName = teamleadName;
        }
        [Key]
        [Required]
        public string TeamleadId { get; set; }
        [Required]
        public string TeamleadName { get; set; }
    }
}