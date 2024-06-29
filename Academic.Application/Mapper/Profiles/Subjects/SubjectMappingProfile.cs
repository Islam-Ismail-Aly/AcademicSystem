using Academic.Application.DTOs.SubjectDTOs;
using Academic.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Mapper.Profiles.Subjects
{
    public class SubjectMappingProfile:Profile
    {
        public SubjectMappingProfile()
        {
            CreateMap<Subject, SubjectDTO>().ForMember(s => s.Name, d => d.MapFrom(d => d.Name))
        .ForMember(s => s.MinDegree, d => d.MapFrom(d => d.MinDegree))
        .ForMember(s => s.MaxDegree, d => d.MapFrom(d => d.MaxDegree));

        }
    }
}
