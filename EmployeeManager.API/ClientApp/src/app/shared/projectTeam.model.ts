import { Project } from "./project.model";
import { Team } from "./team.model";

export class ProjectTeam{
    constructor(public projectTeamID:number,public projectID:number,public teamID:number,public project:Project,public team:Team ){}
}



// public int ProjectTeamID{ get; set; }

// public int ProjectID { get; set; }
// public Project Project { get; set; }

// public int TeamID { get; set; }
// public Team Team { get; set; }

// public DateTime CreatedDate { get; set ; }
// public int CreatedUserId { get; set ; }
// public IdentityUser<int> CreatedUser { get; set; }

// public DateTime? ModifiedDate { get; set ; }
// public int? ModifiedUserId { get; set; }
// public IdentityUser<int> ModifiedUser { get; set ; }

// public DateTime? DeletedDate { get; set; }
// public int? DeletedUserId { get; set; }
// public IdentityUser<int> DeletedUser { get; set; }