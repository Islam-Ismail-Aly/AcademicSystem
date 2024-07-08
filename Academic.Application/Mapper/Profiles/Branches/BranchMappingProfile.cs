using Academic.Application.DTOs.Branch;
using Academic.Core.Entities;
using AutoMapper;

namespace Academic.Application.Mapper.Profiles.Branches
{
    public class BranchMappingProfile : Profile
    {
        public BranchMappingProfile()
        {
            CreateMap<Branch, BranchDTO>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Telephone, opt => opt.MapFrom(src => src.Telephone))
                    .ForMember(dest => dest.SupervisorId, opt => opt.MapFrom(src => src.SupervisorId)).ReverseMap();
                    

            CreateMap<BranchDTO, Branch>()
                    .ForMember(dest => dest.Supervisor, opt => opt.Ignore())
                    .ForMember(dest => dest.ApplicationUsers, opt => opt.Ignore());
        }
    }
}
