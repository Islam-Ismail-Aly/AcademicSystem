using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.DTOs.Subjects
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double MinDegree { get; set; }
        public double MaxDegree { get; set; }
    }
}
