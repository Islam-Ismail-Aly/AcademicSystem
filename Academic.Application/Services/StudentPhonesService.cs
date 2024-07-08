using Academic.Application.DTOs.Student;
using Academic.Application.DTOs.StudentPhones;
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
    public class StudentPhonesService : IStudentPhoneService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork<T> _unitOfWork;
        public StudentPhonesService(IUnitOfWork<T> _unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this._unitOfWork = _unitOfWork;
        }
        public async Task<APIResponseResult<bool>> AddStudentPhone(StudentPhonesDTO studentPhoneDTO)
        {
            var studentPhone=new T() { StudentId=studentPhoneDTO.StudentId,Phone=studentPhoneDTO.Phone };
           await _unitOfWork.Entity.InsertAsync(studentPhone);
             await _unitOfWork.SaveAsync();

            return new APIResponseResult<bool>(true, "StudentPhone is added successfully");
        }

        public async Task<APIResponseResult<bool>> DeleteStudentPhone(int id, string Phone)
        {
            var student =  _unitOfWork.Element.GetElement(s => s.StudentId == id && s.Phone == Phone, null);

            if (student is null)
                return new APIResponseResult<bool>(false, "StudentPhone is not found");

             _unitOfWork.Element.DeleteElement(student);
            await _unitOfWork.SaveAsync();

            return new APIResponseResult<bool>(true, "StudentPhone is deleted successfully");
        }

        public async Task<APIResponseResult<IEnumerable<StudentPhonesDTO>>> GetAllStudentPhone()
        {
            var studentPhones = await _unitOfWork.Entity.GetAllAsync();
            var StudentPhoneDTOs = new List<StudentPhonesDTO>();
            if (studentPhones is null)
                return new APIResponseResult<IEnumerable<StudentPhonesDTO>>(null, "StudentPhones are not found");
            foreach (var student in studentPhones)
            {
                StudentPhonesDTO dto = mapper.Map<StudentPhonesDTO>(student);
               
                StudentPhoneDTOs.Add(dto);

            }
            return new APIResponseResult<IEnumerable<StudentPhonesDTO>>(StudentPhoneDTOs, "All Students are Retrieved Successfully");
        
    }

        public async Task<APIResponseResult<IEnumerable<StudentPhonesDTO>>> GetAllStudentPhonesByStudentId(int studentId)
        {
            var studentPhones = _unitOfWork.Element.GetElements(s=>s.StudentId==studentId,null);
            var StudentPhoneDTOs = new List<StudentPhonesDTO>();
            if (studentPhones is null)
                return new APIResponseResult<IEnumerable<StudentPhonesDTO>>(null, "StudentPhones are not found");
            foreach (var student in studentPhones)
            {
                StudentPhonesDTO dto = mapper.Map<StudentPhonesDTO>(student);

                StudentPhoneDTOs.Add(dto);

            }
            return new APIResponseResult<IEnumerable<StudentPhonesDTO>>(StudentPhoneDTOs, "All Students are Retrieved Successfully");

        }

        public async Task<APIResponseResult<StudentPhonesDTO>> GetStudentPhoneById(int studentId, string Phone)
        {
            var studentPhone =  _unitOfWork.Element.GetElement(s=>s.StudentId==studentId&&s.Phone==Phone,null);

            if (studentPhone ==null)
                return new APIResponseResult<StudentPhonesDTO>(null, "StudentPhone is not found");

            var studentPhoneDTO = mapper.Map<StudentPhonesDTO>(studentPhone);
            return new APIResponseResult<StudentPhonesDTO>(studentPhoneDTO, "StudentPhone is Retrieved Successfully");
        
    }

        public async Task<APIResponseResult<bool>> UpdateStudentPhone(StudentPhonesDTO studentPhoneDTO)
        {
            var studentPhone = new T() { StudentId = studentPhoneDTO.StudentId, Phone = studentPhoneDTO.Phone };
            await _unitOfWork.Entity.UpdateAsync(studentPhone);
            await _unitOfWork.SaveAsync();

            return new APIResponseResult<bool>(true, "StudentPhone is Updated successfully");
        }
    }
}
