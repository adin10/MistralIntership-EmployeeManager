using AutoMapper;
using EmployeeManager.API.Models;
using EmployeeManager.Infrastructure.Requests;

namespace EmployeeManager.API
{
    public class MapperApi:Profile
    {

        public MapperApi()
        {
            CreateMap<TeamRestUpsertModel, TeamUpdateRequest>().ReverseMap();
            CreateMap<TeamRestUpsertModel, TeamInsertRequest>().ReverseMap();

            CreateMap<EmployeeTeamRestUpsertModel, EmployeeTeamInsertRequest>().ReverseMap();
            CreateMap<EmployeeTeamRestUpsertModel, EmployeeTeamUpdateRequest>().ReverseMap();

            CreateMap<ProjectRestUpsertModel, ProjectInsertRequest>().ReverseMap();
            CreateMap<ProjectRestUpsertModel, ProjectUpdateRequest>().ReverseMap();

            CreateMap<ProjectTeamRestUpsertModel, ProjectTeamInsertRequest>().ReverseMap();
            CreateMap<ProjectTeamRestUpsertModel, ProjectTeamUpdateRequest>().ReverseMap();
          
            CreateMap<EmployeeRestUpsertModel, EmployeeInsertRequest>()
                //.ForMember(x => x.ProfilePhotoPath, opt => opt.MapFrom(x => x.PhotoPath))
                .ReverseMap();
            CreateMap<EmployeeUpdateRestUpsertModel, EmployeeUpdateRequest>().ReverseMap();

            CreateMap<UserUpsertRestModel, IdentityUserInsertRequest>().ReverseMap();

            CreateMap<UserUpdateRestModel, IdentityUserUpdateRequest>().ReverseMap();

            CreateMap<TrackingRestUpsertModel, TrackingInsertRequest>().ReverseMap();
            CreateMap<TrackingRestUpsertModel, TrackingUpdateRequest>().ReverseMap();

            CreateMap<ProjectTeamRestUpsertModel, ProjectTeamInsertRequest>().ReverseMap();
        
        }
    }
}
