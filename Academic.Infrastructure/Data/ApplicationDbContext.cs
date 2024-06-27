using Academic.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;

namespace Academic.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSubject> CourseSubjects { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupPermission> GroupPermissions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentAudit> PaymentAudits { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentPhone> StudentPhones { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }

        public ApplicationDbContext()
        { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Configure IdentityUserLogin composite key
            builder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
        }
    }
}
