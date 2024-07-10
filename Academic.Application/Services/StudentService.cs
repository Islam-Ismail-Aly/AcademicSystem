using Academic.Application.DTOs.Student;
using Academic.Application.DTOs.Subjects;
using Academic.Application.Interfaces;
using Academic.Application.Utilities;
using Academic.Core.Entities;
using Academic.Core.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork<Student> _unitOfWork;

        public StudentService(IUnitOfWork<Student> _unitOfWork, IMapper mapper)
        {
            this._unitOfWork = _unitOfWork;
            this.mapper = mapper;
        }
        public  async Task<APIResponseResult<Student>> AddStudentAsync(StudentDTO studentDTO)
        {
            var student = new Student() { AcademicYear=studentDTO.AcademicYear,GraduationYear=studentDTO.GraduationYear,ArabicName=studentDTO.ArabicName,EnglishName=studentDTO.EnglishName,Photo=studentDTO.Photo
            ,QualificationCertificate=studentDTO.QualificationCertificate,IdentityCard=studentDTO.IdentityCard,MilitrayStatus=studentDTO.MilitrayStatus,MoneyPaid=studentDTO.MoneyPaid,
            ApplicationUserId=studentDTO.ApplicationUserId,PaymentId=studentDTO.PaymentId,CourseId=studentDTO.CourseId,BranchId=studentDTO.BranchId,Address=studentDTO.Address,SSN=studentDTO.SSN,DateOfBirth=studentDTO.DateOfBirth,SubmissionDate=studentDTO.SubmissionDate
            ,Religion=studentDTO.Religion,Gender=studentDTO.Gender,Telephone=studentDTO.Telephone,Degree=studentDTO.Degree};

            await _unitOfWork.Entity.InsertAsync(student);
            await _unitOfWork.SaveAsync();

            return new APIResponseResult<Student>(student, "Student is added successfully");
        }

        public async Task<APIResponseResult<bool>> DeleteStudentAsync(int id)
        {
            var student = await _unitOfWork.Entity.GetByIdAsync(id);

            if (student is null)
                return new APIResponseResult<bool>(false, "Student is not found");

            await _unitOfWork.Entity.DeleteAsync(id);
            await _unitOfWork.SaveAsync();

            return new APIResponseResult<bool>(true, "Student is deleted successfully");

        }

        public async Task<APIResponseResult<IEnumerable<StudentDTO>>> GetAllStudentsAsync()
        {
            var students = await _unitOfWork.Entity.GetAllAsync();
            var StudentDTOs= new List<StudentDTO>();
            if (students is null)
                return new APIResponseResult<IEnumerable<StudentDTO>>(null,"Students are not found");
            foreach (var student in students)
            {
                StudentDTO dto = mapper.Map<StudentDTO>(student);
                dto.Id = student.Id;
                StudentDTOs.Add(dto);

            }
            return new APIResponseResult<IEnumerable<StudentDTO>>(StudentDTOs, "All Students are Retrieved Successfully");
        }

        public async Task<APIResponseResult<StudentDTO>> GetStudentByIdAsync(int id)
        {
            var student = await _unitOfWork.Entity.GetByIdAsync(id);

            if (student is null)
                return new APIResponseResult<StudentDTO>(null, "Student is not found");

            var studentDTO = mapper.Map<StudentDTO>(student);
            return new APIResponseResult<StudentDTO>(studentDTO, "Student is Retrieved Successfully");
        }

        public async Task<APIResponseResult<bool>> UpdateStudentAsync(StudentDTO studentDTO)
        {
            var student = new Student()
            {
                Id=studentDTO.Id,
                AcademicYear = studentDTO.AcademicYear,
                GraduationYear = studentDTO.GraduationYear,
                ArabicName = studentDTO.ArabicName,
                EnglishName = studentDTO.EnglishName,
                Photo = studentDTO.Photo
            ,
                QualificationCertificate = studentDTO.QualificationCertificate,
                IdentityCard = studentDTO.IdentityCard,
                MilitrayStatus = studentDTO.MilitrayStatus,
                MoneyPaid = studentDTO.MoneyPaid,
                ApplicationUserId = studentDTO.ApplicationUserId,
                PaymentId = studentDTO.PaymentId,
                CourseId = studentDTO.CourseId,
                BranchId = studentDTO.BranchId,
                Address = studentDTO.Address,
                SSN = studentDTO.SSN,
                DateOfBirth = studentDTO.DateOfBirth,
                SubmissionDate = studentDTO.SubmissionDate
            ,
                Religion = studentDTO.Religion,
                Gender = studentDTO.Gender,
                Telephone = studentDTO.Telephone,
                Degree = studentDTO.Degree
            };
            ;
            await _unitOfWork.Entity.UpdateAsync(student);
            await _unitOfWork.SaveAsync();

            return new APIResponseResult<bool>(true, "Student is updated successfully");
        }
    }
}
