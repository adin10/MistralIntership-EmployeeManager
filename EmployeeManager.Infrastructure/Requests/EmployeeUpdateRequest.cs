using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Requests
{
   public class EmployeeUpdateRequest
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateEmployment { get; set; }
        public string Skils { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserId { get; set; }

        public IdentityUserUpdateRequest User { get; set; }
        public List<EmployeeTeamUpdateRequest> Teams { get; set; }
    }
}
