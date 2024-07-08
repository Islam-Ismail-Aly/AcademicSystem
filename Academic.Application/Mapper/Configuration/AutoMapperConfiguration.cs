using Academic.Application.Mapper.Profiles.Account;
using Academic.Application.Mapper.Profiles.Courses;
using Academic.Application.Mapper.Profiles.CourseSubjects;
using Academic.Application.Mapper.Profiles.Payments;
using Academic.Application.Mapper.Profiles.StudentPhones;
using Academic.Application.Mapper.Profiles.Students;
using Academic.Application.Mapper.Profiles.Subjects;
using Microsoft.Extensions.DependencyInjection;

namespace Academic.Application.Mapper.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperConfiguration),
                typeof(CourseMappingProfile), typeof(CourseSubjectMappingProfile),
                typeof(PaymentMappingProfile),
                typeof(StudentPaymentMappingProfile));
            services.AddAutoMapper(typeof(AutoMapperConfiguration), typeof(UserMappingProfile), typeof(SubjectMappingProfile), typeof(CourseMappingProfile), typeof(CourseSubjectMappingProfile),
                typeof(StudentMappingProfile), typeof(StudentPhoneMappingProfile));
        }
    }
}
