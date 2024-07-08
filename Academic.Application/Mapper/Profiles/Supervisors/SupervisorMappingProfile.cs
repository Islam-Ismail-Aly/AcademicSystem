using Academic.Application.DTOs.Branch;
using Academic.Application.DTOs.Supervisor;
using Academic.Core.Entities;
using AutoMapper;

namespace Academic.Application.Mapper.Profiles.Supervisors
{
    public class SupervisorMappingProfile : Profile
    {
        public SupervisorMappingProfile()
        {
            // Mapping for Branch and BranchDto
            CreateMap<BranchDTO, Branch>()
                .ForMember(dest => dest.Supervisor, opt => opt.Ignore())
                .ForMember(dest => dest.ApplicationUsers, opt => opt.Ignore());

            // Mapping for Supervisor and SupervisorDto
            CreateMap<Supervisor, SupervisorDTO>()
                .ForMember(dest => dest.ApplicationUserName, opt => opt.MapFrom(src => src.ApplicationUser.UserName))
                .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.ApplicationUser.Branch.Name));
            CreateMap<SupervisorDTO, Supervisor>()
                .ForMember(dest => dest.ApplicationUser, opt => opt.Ignore());
        }
    }
}
