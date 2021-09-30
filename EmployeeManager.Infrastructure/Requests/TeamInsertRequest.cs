using System;
using System.Collections.Generic;

namespace EmployeeManager.Infrastructure.Requests
{

    public class TeamInsertRequest
    {
        public string TeamName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedUserId { get; set; }
    }
}
