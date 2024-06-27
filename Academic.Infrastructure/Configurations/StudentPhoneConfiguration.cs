using Academic.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academic.Infrastructure.Configurations
{
    internal class StudentPhoneConfiguration : IEntityTypeConfiguration<StudentPhone>
    {
        public void Configure(EntityTypeBuilder<StudentPhone> builder)
        {
            builder.HasKey(table => new { table.StudentId, table.Phone });
        }
    }
}
