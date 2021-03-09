using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCReleaseManagementAssignmentOneProject.Models
{
    public class EmployeeDetails
    {
        public EmployeeDetails()
        {

        }
        public EmployeeDetails(string employeeId, string employeeName, string username, string password, string role)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            Username = username;
            Password = password;
            Role = role;
        }
        [Key]
        [Required]
        public string EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}