export class Project{
    constructor(public projectID:number,
                public projectName:string,
                public startDate:Date,
                public finishDate:Date,
                public projectTeams:ProjectTeam[]){}
    }

    export class ProjectTeam {
        constructor(public teamID: number){}
    }

// public int ProjectID { get; set; }
// public string ProjectName { get; set; }
// public DateTime StartDate { get; set; }
// public DateTime FinishDate { get; set; }
// public DateTime CreatedDate { get ; set; }
// public int CreatedUserId { get; set; }
// public IdentityUser<int> CreatedUser { get ; set ; }
// public DateTime? ModifiedDate { get ; set ; }
// public int? ModifiedUserId { get; set; }
// public IdentityUser<int> ModifiedUser { get; set; }
// public DateTime? DeletedDate { get; set ; }
// public int? DeletedUserId { get; set; }
// public IdentityUser<int> DeletedUser { get; set; }