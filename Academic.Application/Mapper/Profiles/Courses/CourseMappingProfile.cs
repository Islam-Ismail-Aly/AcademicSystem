using Academic.Application.DTOs.CourseDTO;
using Academic.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Mapper.Profiles.Courses
{
    public class CourseMappingProfile:Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<Course, CourseDTO>().ForMember(s => s.Name, d => d.MapFrom(d => d.Name))
       .ForMember(s => s.TotalHours, d => d.MapFrom(d => d.TotalHours))
       .ForMember(s => s.Description, d => d.MapFrom(d => d.Description))
        .ForMember(s => s.Price, d => d.MapFrom(d => d.Price));
        }
    }
}
