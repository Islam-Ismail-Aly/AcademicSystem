using Academic.Core.Abstraction;

namespace Academic.Core.Entities
{
    public class Course : BaseEntity
    {
        public string Description { get; set; }
        public double TotalHours { get; set; }
        public decimal Price { get; set; }
        public ICollection<CourseSubject> CourseSubjects { get; set; } = new List<CourseSubject>();
    }
}
