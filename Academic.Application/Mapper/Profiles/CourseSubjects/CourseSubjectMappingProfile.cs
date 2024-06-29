using Academic.Application.DTOs.CourseDTO;
using Academic.Application.DTOs.CourseSubjects;
using Academic.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Mapper.Profiles.CourseSubjects
{
    public class CourseSubjectMappingProfile:Profile
    {
        public CourseSubjectMappingProfile()
        {
            CreateMap<CourseSubject, CourseSubjectsDTO>().ForMember(s => s.CourseId, d => d.MapFrom(d => d.CourseId))
       .ForMember(s => s.SubjectId, d => d.MapFrom(d => d.SubjectId));
        }
    }
}
