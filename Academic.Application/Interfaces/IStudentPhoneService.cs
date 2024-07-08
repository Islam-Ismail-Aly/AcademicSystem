using Academic.Application.DTOs.Student;
using Academic.Application.DTOs.StudentPhones;
using Academic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Interfaces
{
    public interface IStudentPhoneService
    {
        Task<APIResponseResult<IEnumerable<StudentPhonesDTO>>> GetAllStudentPhone();
        Task<APIResponseResult<IEnumerable<StudentPhonesDTO>>> GetAllStudentPhonesByStudentId(int studentId);
        Task<APIResponseResult<StudentPhonesDTO>> GetStudentPhoneById(int studentId,string Phone);
        Task<APIResponseResult<bool>> AddStudentPhone(StudentPhonesDTO studentPhoneDTO);
        Task<APIResponseResult<bool>> UpdateStudentPhone(StudentPhonesDTO studentPhoneDTO);
        Task<APIResponseResult<bool>> DeleteStudentPhone(int id,string Phone);
    }
}
