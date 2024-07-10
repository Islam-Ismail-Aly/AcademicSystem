using Academic.Application.DTOs.Student;
using Academic.Application.Utilities;
using Academic.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Interfaces
{
    public interface IStudentService
    {
        Task<APIResponseResult<IEnumerable<StudentDTO>>> GetAllStudentsAsync();
        Task<APIResponseResult<StudentDTO>> GetStudentByIdAsync(int id);
        Task<APIResponseResult<Student>> AddStudentAsync(StudentDTO studentDTO);
        Task<APIResponseResult<bool>> UpdateStudentAsync(StudentDTO studentDTO);
        Task<APIResponseResult<bool>> DeleteStudentAsync(int id);
    }
}
