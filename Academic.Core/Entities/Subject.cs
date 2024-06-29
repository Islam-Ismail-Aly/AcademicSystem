using Academic.Core.Abstraction;
using System.ComponentModel.DataAnnotations;

namespace Academic.Core.Entities
{
    public class Subject : BaseEntity
    {
        [Range(0, 100)]
        public double? MinDegree { get; set; }

        [Range(0, 100)]
        public double? MaxDegree { get; set; }
        public ICollection<CourseSubject> CourseSubjects { get; private set; } = new HashSet<CourseSubject>();
    }
}
