import { Team } from "../team.model";

export class ProjectUpdateRequest{
    constructor(public ProjectName:string,public StartDate:Date,public FinishDate:Date,public teams: Team[]){}
}