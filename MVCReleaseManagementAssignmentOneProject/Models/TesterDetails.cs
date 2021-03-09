using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCReleaseManagementAssignmentOneProject.Models
{
    public class TesterDetails
    {
        public TesterDetails()
        {

        }
        public TesterDetails(string testerId,string testerName)
        {
            TesterId = testerId;
            TesterName = testerName;
        }
        [Key]
        [Required]
        public string TesterId { get; set; }
        [Required]
        public string TesterName { get; set; }
    }
}