using Academic.Application.DTOs.Student;
using Academic.Application.DTOs.Subjects;
using Academic.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Mapper.Profiles.Students
{
    public class StudentMappingProfile:Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<Student,StudentDTO>().ForMember(s => s.ArabicName, d => d.MapFrom(d => d.ArabicName))
        .ForMember(s => s.EnglishName, d => d.MapFrom(d => d.EnglishName))
        .ForMember(s => s.Address, d => d.MapFrom(d => d.Address))
        .ForMember(s => s.DateOfBirth, d => d.MapFrom(d => d.DateOfBirth))
        .ForMember(s => s.SubmissionDate, d => d.MapFrom(d => d.SubmissionDate))
        .ForMember(s => s.GraduationYear, d => d.MapFrom(d => d.GraduationYear))
        .ForMember(s => s.AcademicYear, d => d.MapFrom(d => d.AcademicYear))
        .ForMember(s => s.Photo, d => d.MapFrom(d => d.Photo))
        .ForMember(s => s.QualificationCertificate, d => d.MapFrom(d => d.QualificationCertificate))
        .ForMember(s => s.IdentityCard, d => d.MapFrom(d => d.IdentityCard))
        .ForMember(s => s.SSN, d => d.MapFrom(d => d.SSN))
        .ForMember(s => s.MilitrayStatus, d => d.MapFrom(d => d.MilitrayStatus))
        .ForMember(s => s.Gender, d => d.MapFrom(d => d.Gender))
        .ForMember(s => s.Degree, d => d.MapFrom(d => d.Degree))
        .ForMember(s => s.Religion, d => d.MapFrom(d => d.Religion))
        .ForMember(s => s.Telephone, d => d.MapFrom(d => d.Telephone))
        .ForMember(s => s.MoneyPaid, d => d.MapFrom(d => d.MoneyPaid))
        .ForMember(s => s.PaymentId, d => d.MapFrom(d => d.PaymentId))
        .ForMember(s => s.CourseId, d => d.MapFrom(d => d.CourseId))
        .ForMember(s => s.BranchId, d => d.MapFrom(d => d.BranchId))
        .ForMember(s => s.ApplicationUserId, d => d.MapFrom(d => d.ApplicationUserId))
        ;
        }
    }
}
