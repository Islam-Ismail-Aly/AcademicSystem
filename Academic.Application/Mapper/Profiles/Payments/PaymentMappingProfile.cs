using Academic.Application.DTOs.PaymentDetailsDTO;
using Academic.Application.DTOs.PaymentDTOs;
using Academic.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Mapper.Profiles.Payments
{
    public class PaymentMappingProfile : Profile
    {
        public PaymentMappingProfile() 
        {
            CreateMap<Payment, PaymentDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.MoneyPaid, opt => opt.MapFrom(src => src.MoneyPaid))
                 .ForMember(dest => dest.RestOfMoney, opt => opt.MapFrom(src => src.RestOfMoney))
                 .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State.Value))
                 .ForMember(dest => dest.NominatingAuthority, opt => opt.MapFrom(src => src.NominatingAuthority))
                 .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes));

            






            CreateMap<Payment, PaymentDetailsDTO>();

            CreateMap<Student, StudentCoursesPaymentDetailsDTO>()
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Payment.State))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Payment.Notes))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Course.Price));
        }
    }
}
