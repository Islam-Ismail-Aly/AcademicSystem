using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.DTOs.Course
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double TotalHours { get; set; }
        public decimal Price { get; set; }
    }
}
