using Academic.Application.DTOs.StudentDTOs;
using Academic.Core.Entities;
using AutoMapper;

namespace Academic.Application.Mapper.Profiles.Students
{
    public class StudentPaymentMappingProfile : Profile
    {
        public StudentPaymentMappingProfile()
        {
            CreateMap<Student, StudentNamesPaymentDTO>()
                .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.ApplicationUser.Id))
                .ForMember(dest => dest.userName, opt => opt.MapFrom(src => src.ApplicationUser.UserName));
        }
    }
}
