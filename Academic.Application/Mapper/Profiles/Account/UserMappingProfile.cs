using Academic.Application.DTOs.Account;
using Academic.Core.Entities;
using AutoMapper;

namespace Academic.Application.Mapper.Profiles.Account
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDTO>()
                .ForMember(d => d.FullName, s => s.MapFrom(s => s.FullName))
                .ForMember(d => d.UserName, s => s.MapFrom(s => s.FullName))
                .ForMember(d => d.Email, s => s.MapFrom(s => s.Email))
                .ForMember(d => d.GroupId, s => s.MapFrom(s => s.GroupId))
                .ForMember(d => d.BranchId, s => s.MapFrom(s => s.BranchId))
                .ForMember(d => d.Language, s => s.MapFrom(s => s.Language)).ReverseMap();
        }
    }
}
