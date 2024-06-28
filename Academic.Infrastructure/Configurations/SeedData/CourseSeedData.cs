using Academic.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academic.Infrastructure.Configurations.SeedData
{
    public class CourseSeedData : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData(
                new Course { Id = 1, Name = "Calculus", Description = "Advanced Mathematics Course", TotalHours = 40, Price = 299.99m },
                     new Course { Id = 2, Name = "Mechanics", Description = "Introduction to Physics", TotalHours = 30, Price = 199.99m },
                     new Course { Id = 3, Name = "Organic Chemistry", Description = "Comprehensive Chemistry Course", TotalHours = 35, Price = 249.99m }
            );
        }
    }
}
