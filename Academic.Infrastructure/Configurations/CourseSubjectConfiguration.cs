using Academic.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academic.Infrastructure.Configurations
{
    public class CourseSubjectConfiguration : IEntityTypeConfiguration<CourseSubject>
    {
        public void Configure(EntityTypeBuilder<CourseSubject> builder)
        {
            builder.HasKey(table => new { table.SubjectId, table.CourseId });
        }
    }
}
