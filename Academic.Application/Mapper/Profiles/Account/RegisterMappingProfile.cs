using Academic.Application.DTOs.Account;
using Academic.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Mapper.Profiles.Account
{
    public class RegisterMappingProfile : Profile
    {
        public RegisterMappingProfile()
        {
            CreateMap<ApplicationUser, RegisterDTO>()
         .ForMember(d => d.FullName, s => s.MapFrom(s => s.FullName))
                .ForMember(d => d.UserName, s => s.MapFrom(s => s.FullName))
                .ForMember(d => d.Email, s => s.MapFrom(s => s.Email))
                .ForMember(d => d.GroupId, s => s.MapFrom(s => s.GroupId))
                .ForMember(d => d.BranchId, s => s.MapFrom(s => s.BranchId))
                .ForMember(d => d.Language, s => s.MapFrom(s => s.Language)).ReverseMap();
        }
    }
}
