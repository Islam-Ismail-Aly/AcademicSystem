using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Constants
{
    public class StudentControllerSwaggerAttributes
    {
        public const string GetAllStudentSummary = "Retrieves all Students.";
        public const string GetStudentByIdSummary = "Retrieves the student by its Id.";
        public const string AddStudentSummary = "Adds a new Student.";
        public const string UpdateStudentSummary = "Updates an existing Student.";
        public const string DeleteStudentSummary = "Deletes an existing student.";

        public const string GetAllStudentResponse200 = "A list of students with detailed information.";
        public const string GetAllStudentResponse404 = "If no students are found.";

        public const string GetStudentByIdResponse200 = "If the student is found.";
        public const string GetStudentByIdResponse404 = "If the student is not found.";

        public const string AddStudentResponse201 = "Student added successfully.";
        public const string AddStudentResponse400 = "Invalid Student data.";

        public const string UpdateStudentResponse204 = "Student updated successfully.";
        public const string UpdateStudentResponse400 = "Invalid Student data.";
        public const string UpdateStudentResponse404 = "If the Student is not found.";

        public const string DeleteStudentResponse204 = "Branch student successfully.";
        public const string DeleteStudentResponse404 = "If the student is not found.";
    }
}
