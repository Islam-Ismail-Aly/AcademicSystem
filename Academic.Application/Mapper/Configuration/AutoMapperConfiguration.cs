using Academic.Application.Mapper.Profiles.Account;
using Academic.Application.Mapper.Profiles.Courses;
using Academic.Application.Mapper.Profiles.CourseSubjects;
using Academic.Application.Mapper.Profiles.Subjects;
using Microsoft.Extensions.DependencyInjection;

namespace Academic.Application.Mapper.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperConfiguration), typeof(UserMappingProfile),typeof(SubjectMappingProfile),typeof(CourseMappingProfile),typeof(CourseSubjectMappingProfile));
        }
    }
}
