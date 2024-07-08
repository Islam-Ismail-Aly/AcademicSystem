using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Constants
{
    public class CourseSubjectControllerSwaggerAttribute
    {
        public const string GetAllCourseSubjectSummary = "Retrieves all CourseSubjects.";
        public const string GetCourseSubjectByIdSummary = "Retrieves the CourseSubject by its Id.";
        public const string AddCourseSubjectSummary = "Adds a new CourseSubject.";
        public const string UpdateCourseSubjectSummary = "Updates an existing CourseSubject.";
        public const string DeleteCourseSubjectSummary = "Deletes an existing CourseSubject.";

        public const string GetAlCourseSubjectResponse200 = "A list of CourseSubject with detailed information.";
        public const string GetAllCourseSubjectResponse404 = "If no CourseSubject are found.";

        public const string GetCourseSubjectByIdResponse200 = "If the CourseSubject is found.";
        public const string GetCourseSubjectByIdResponse404 = "If the CourseSubject is not found.";

        public const string AddCourseSubjectResponse201 = "CourseSubject added successfully.";
        public const string AddCourseSubjectResponse400 = "Invalid CourseSubject data.";

        public const string UpdateCourseSubjectResponse204 = "CourseSubject updated successfully.";
        public const string UpdateCourseSubjectResponse400 = "Invalid CourseSubject data.";
        public const string UpdateCourseSubjectResponse404 = "If the CourseSubject is not found.";

        public const string DeleteCourseSubjectResponse204 = "CourseSubject is deleted successfully.";
        public const string DeleteCourseSubjectResponse404 = "If the CourseSubject is not found.";
    }
}
