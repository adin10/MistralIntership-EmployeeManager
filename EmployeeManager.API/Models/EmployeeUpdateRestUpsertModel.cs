using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.API.Models
{
    public class EmployeeUpdateRestUpsertModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateEmployment { get; set; }
        public string Skils { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }
        public UserUpdateRestModel User { get; set; }
        public List<EmployeeTeamRestUpsertModel> Teams { get; set; }
    }
}
