using Academic.Core.Entities;
using Academic.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.DTOs.Student
{
    public class StudentDTO
    {
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
        public int? PaymentId { get; set; }
        public int? CourseId { get; set; }
        public int? BranchId { get; set; }
        public string? ApplicationUserId { get; set; }
    }
}
