using System.ComponentModel.DataAnnotations.Schema;

namespace Academic.Core.Entities
{
    public class CourseSubject
    {
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public Course Course { get; set; }

        [ForeignKey("Subject")]
        public int? SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
