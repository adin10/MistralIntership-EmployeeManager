﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Requests
{
   public class EmployeeTeamUpdateRequest
    {
        //public int EmployeeID { get; set; }
        public int TeamID { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserId { get; set; }
    }
}
