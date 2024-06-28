using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Academic.Core.Helpers;

namespace Academic.Core.Entities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string GraduationYear { get; set; }
        public string AcademicYear { get; set; }
        public string Photo { get; set; }
        public string QualificationCertificate { get; set; }
        public string IdentityCard { get; set; }
        public string SSN { get; set; }
        public MilitaryStatus MilitrayStatus { get; set; }
        public Gender Gender { get; set; }
        public string Degree { get; set; }
        public Religion Religion { get; set; }
        public string Telephone { get; set; }
        public decimal MoneyPaid { get; set; }

        [ForeignKey("Payment")]
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<StudentPhone>  StudentPhones{ get; set; } = new List<StudentPhone>();
    }
}
