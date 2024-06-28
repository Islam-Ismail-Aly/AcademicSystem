using Academic.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academic.Infrastructure.Configurations.SeedData
{
    public class SubjectSeedData : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasData(
                new Subject { Id = 1, Name = "Mathematics", MinDegree = 50, MaxDegree = 100 },
                     new Subject { Id = 2, Name = "Physics", MinDegree = 45, MaxDegree = 95 },
                     new Subject { Id = 3, Name = "Chemistry", MinDegree = 40, MaxDegree = 90 }
            );
        }
    }
}
