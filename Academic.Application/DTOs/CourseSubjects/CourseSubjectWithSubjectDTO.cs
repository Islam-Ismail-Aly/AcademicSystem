using Academic.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.DTOs.CourseSubjects
{
    public class CourseSubjectWithSubjectDTO
    {
        public int? CourseId { get; set; }
        public int? SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
