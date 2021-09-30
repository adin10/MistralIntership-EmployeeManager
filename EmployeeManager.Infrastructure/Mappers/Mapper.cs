using AutoMapper;
using EmployeeManager.Database;
using EmployeeManager.Infrastructure.Requests;
using EmployeeManager.Infrastructure.Response;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Mappers
{
   public class Mapper:Profile
    {
        public Mapper()
        {

            CreateMap<EmployeeInsertRequest, Employee>();
            CreateMap<EmployeeUpdateRequest, Employee>();

            CreateMap<TeamInsertRequest, Team>().ReverseMap();
            CreateMap<TeamUpdateRequest, Team>().ReverseMap();
            
            CreateMap<EmployeeTeamInsertRequest, EmployeeTeam>();
            CreateMap<EmployeeTeamUpdateRequest, EmployeeTeam>().ReverseMap();

            CreateMap<ProjectInsertRequest, Project>().ReverseMap();
            CreateMap<ProjectUpdateRequest, Project>().ReverseMap();

            CreateMap<ProjectTeamInsertRequest, ProjectTeam>().ReverseMap();
            CreateMap<ProjectTeamUpdateRequest, ProjectTeam>().ReverseMap();

            CreateMap<IdentityUserInsertRequest, IdentityUser<int>>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Username))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(x => x.PasswordHash, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<IdentityUserUpdateRequest, IdentityUser<int>>()
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
                .ForAllOtherMembers(x => x.Ignore());



            CreateMap<Project, ProjectResponse>().ReverseMap();
            CreateMap<ProjectTeamResponse, ProjectTeam>().ReverseMap();
            CreateMap<Team, TeamResponse>().ReverseMap();
            CreateMap<Employee, EmployeeResponse>().ReverseMap();
            CreateMap<IdentityUser<int>, UserResponse>();

            CreateMap<ProjectTeamInsertRequest, ProjectTeam>().ReverseMap();

            CreateMap<EmployeeTeamInsertRequest, EmployeeTeam>();
            CreateMap<EmployeeTeam, EmployeeTeamResponse>().ReverseMap();
            CreateMap<EmployeeTeamUpdateRequest, EmployeeTeam>().ReverseMap();

            CreateMap<TrackingInsertRequest, Tracking>().ReverseMap();
            CreateMap<TrackingUpdateRequest, Tracking>().ReverseMap();
            CreateMap<Tracking, TrackingResponse>().ReverseMap();
        }
    }
}
