import { Employee } from "./employee.model";
import { Team } from "./team.model";

export class EmployeeTeam{
    constructor(public employeeTeamID:number,public employeeID:number,public teamID:number,public employee:Employee,public team:Team ){}
}

// public int EmployeeTeamID { get; set; }
        
// public int EmployeeID { get; set; }
// public Employee Employee { get; set; }

// public int TeamID { get; set; }
// public Team Team { get; set; }

// public DateTime CreatedDate { get; set; }

// public int CreatedUserId { get; set; }
// public IdentityUser<int> CreatedUser { get; set; }

// public DateTime? ModifiedDate { get; set; }

// public int? ModifiedUserId { get; set; }
// public IdentityUser<int> ModifiedUser { get; set; }

// public DateTime? DeletedDate { get; set; }
// public int? DeletedUserId { get; set ; }
// public IdentityUser<int> DeletedUser { get; set; }