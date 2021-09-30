using System;

namespace EmployeeManager.Infrastructure.Requests
{
    public class ProjectTeamInsertRequest
    {
        public int TeamID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
    }
}
