using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCReleaseManagementAssignmentOneProject.Models
{
    public class ReleaseManagementContext:DbContext
    {
        public ReleaseManagementContext() : base("connectionRMS")
        {

        }
        public DbSet<EmployeeDetails> RegisterEmployeesProp { get; set; }
        public DbSet<ProjectDetails> AddProjectProp { get; set; }
        public DbSet<TeamDetails> TeamDetailsProp { get; set; }
        public DbSet<TeamleadDetails> TeamleadDetailsProp { get; set; }
        public DbSet<DeveloperDetails> DeveloperDetailsProp { get; set; }
        public DbSet<TesterDetails> TesterDetailsProp { get; set; }
        public DbSet<ModuleDetails> ModuleDetailsProp { get; set; }
        public DbSet<BugsDetails> BugsDetailsProp { get; set; }
        public DbSet<CompletedModules> CompletedModulesProp { get; set; }
        public DbSet<CompletedProjects> CompletedProjectsProp { get; set; }
    }
}