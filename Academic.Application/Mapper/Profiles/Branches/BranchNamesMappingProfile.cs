using Academic.Application.DTOs.Branch;
using Academic.Core.Entities;
using AutoMapper;

namespace Academic.Application.Mapper.Profiles.Branches
{
    public class BranchNamesMappingProfile : Profile
    {
        public BranchNamesMappingProfile()
        {
            CreateMap<Branch, BranchNamesDTO>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Name));

            CreateMap<BranchNamesDTO, Branch>()
                    .ForMember(dest => dest.Supervisor, opt => opt.Ignore())
                    .ForMember(dest => dest.ApplicationUsers, opt => opt.Ignore());
        }
    }
}
