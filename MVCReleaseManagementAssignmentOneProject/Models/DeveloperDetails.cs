using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCReleaseManagementAssignmentOneProject.Models
{
    public class DeveloperDetails
    {
        public DeveloperDetails()
        {

        }
        public DeveloperDetails(string developerId,string developerName)
        {
            DeveloperId = developerId;
            DeveloperName = developerName;
        }
        [Key]
        [Required]
        public string DeveloperId { get; set; }
        [Required]
        public string DeveloperName { get; set; }
    }
}