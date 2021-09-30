import { Team } from "../team.model";

export class projectInsertRequest{
   constructor(public ProjectName:string,public StartDate:Date,public FinishDate:Date, public teams: Team[]){}
}


// public string ProjectName { get; set; }
// public DateTime StartDate { get; set; }
// public DateTime FinishDate { get; set; }
