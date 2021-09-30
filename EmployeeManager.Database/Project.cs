using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace EmployeeManager.Database
{
    public class Project:IAuditable
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime CreatedDate { get ; set; }
        public int CreatedUserId { get; set; }
        public IdentityUser<int> CreatedUser { get ; set ; }
        public DateTime? ModifiedDate { get ; set ; }
        public int? ModifiedUserId { get; set; }
        public IdentityUser<int> ModifiedUser { get; set; }
        public DateTime? DeletedDate { get; set ; }
        public int? DeletedUserId { get; set; }
        public IdentityUser<int> DeletedUser { get; set; }

        public ICollection<ProjectTeam> ProjectTeams { get; set; }
    }
}
