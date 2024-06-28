using Academic.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academic.Infrastructure.Configurations.SeedData
{
    public class CourseSubjectSeedData : IEntityTypeConfiguration<CourseSubject>
    {
        public void Configure(EntityTypeBuilder<CourseSubject> builder)
        {
            builder.HasData(
                new CourseSubject { CourseId = 1, SubjectId = 1 },
                     new CourseSubject { CourseId = 2, SubjectId = 2 },
                     new CourseSubject { CourseId = 3, SubjectId = 3 }
            );
        }
    }
}
