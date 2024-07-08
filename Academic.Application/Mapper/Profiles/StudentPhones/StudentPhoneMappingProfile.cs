using Academic.Application.DTOs.Course;
using Academic.Application.DTOs.StudentPhones;
using Academic.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Mapper.Profiles.StudentPhones
{
    public class StudentPhoneMappingProfile:Profile
    {
        public StudentPhoneMappingProfile()
        {
            CreateMap<T, StudentPhonesDTO>().ForMember(s => s.StudentId, d => d.MapFrom(d => d.StudentId))
       .ForMember(s => s.Phone, d => d.MapFrom(d => d.Phone))
       ;
        }
    }
}
