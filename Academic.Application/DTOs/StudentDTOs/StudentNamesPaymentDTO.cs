using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.DTOs.StudentDTOs
{
    public class StudentNamesPaymentDTO
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string userName { get; set; }

    }
}
