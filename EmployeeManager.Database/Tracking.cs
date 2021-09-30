using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Database
{
   public class Tracking:IAuditable
    {
        public int TrackingID { get; set; }

        public int EmployeeTeamID { get; set; }
        public EmployeeTeam EmployeeTeam { get; set; }

        public int ProjectTeamID { get; set; }
        public ProjectTeam ProjectTeam { get; set; }
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public int WorkHours { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedUserId { get; set; }
        public IdentityUser<int> CreatedUser { get;set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedUserId { get; set; }
        public IdentityUser<int> ModifiedUser { get; set; }

        public DateTime? DeletedDate { get; set; }
        
        public int? DeletedUserId { get; set; }
        public IdentityUser<int> DeletedUser { get ; set ; }
    }

}
