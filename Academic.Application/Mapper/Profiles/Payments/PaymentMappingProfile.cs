using Academic.Application.DTOs.PaymentDetailsDTO;
using Academic.Application.DTOs.PaymentDTOs;
using Academic.Core.Entities;
using AutoMapper;

namespace Academic.Application.Mapper.Profiles.Payments
{
    public class PaymentMappingProfile : Profile
    {
        public PaymentMappingProfile()
        {
            CreateMap<Payment, PaymentDTO>()
                .ForMember(dest => dest.MoneyPaid, opt => opt.MapFrom(src => src.MoneyPaid))
                .ForMember(dest => dest.RestOfMoney, opt => opt.MapFrom(src => src.RestOfMoney))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State.Value))
                .ForMember(dest => dest.NominatingAuthority, opt => opt.MapFrom(src => src.NominatingAuthority))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes));
                //.ForMember(dest => dest.TransactionDate, opt => opt.Ignore()) // Ignore TransactionDate
                //.ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.PaymentAudits.Select(p=>p.ApplicationUserId)));


            CreateMap<Payment, PaymentDetailsDTO>();

            CreateMap<Student, StudentPaymentAuditDTO>()
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Payment.State))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Course.Price));
        }
    }
}
