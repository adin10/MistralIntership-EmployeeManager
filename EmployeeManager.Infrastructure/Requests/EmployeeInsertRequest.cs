using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Requests
{
   public class EmployeeInsertRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateEmployment { get; set; }
        public string Skils { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        //public string ProfilePhotoPath { get; set; }
        public int CreatedUserId { get; set; }
        public IdentityUserInsertRequest User { get; set; }
        public List<EmployeeTeamInsertRequest> Teams { get; set; }
    }
}
