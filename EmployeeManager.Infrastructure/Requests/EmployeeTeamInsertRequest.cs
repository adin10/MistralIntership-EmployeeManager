using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Requests
{
   public class EmployeeTeamInsertRequest
    {
        public int TeamID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
        //public DateTime? ModifiedDate { get; set; }
        //public int? ModifiedUserId { get; set; }
        //public DateTime? DeletedDate { get; set; }
        //public int? DeletedUserId { get; set; }

    }
}
