using Academic.Application.DTOs.CourseSubjects;
using Academic.Application.DTOs.StudentPhones;
using Academic.Application.DTOs.Subjects;
using Academic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Interfaces
{
    public interface ICourseSubjectService
    {
        Task<APIResponseResult<IEnumerable<CourseSubjectsDTO>>> GetAllCourseSubjects();
        Task<APIResponseResult<IEnumerable<SubjectDTO>>> GetAllCourseSubjectsByCourseId(int CourseId);

        Task<APIResponseResult<CourseSubjectsDTO>> GetCourseSubjectsById(int CourseId, int SubjectId);
        Task<APIResponseResult<bool>> AddCourseSubjects(CourseSubjectsDTO courseSubjectsDTO);
        Task<APIResponseResult<bool>> UpdatecourseSubject(CourseSubjectsDTO courseSubjectDTO);
        Task<APIResponseResult<bool>> DeletecourseSubject(int CourseId, int SubjectId);
    }
}
