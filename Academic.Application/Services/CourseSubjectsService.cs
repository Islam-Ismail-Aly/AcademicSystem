using Academic.Application.DTOs.CourseSubjects;
using Academic.Application.DTOs.Student;
using Academic.Application.DTOs.StudentPhones;
using Academic.Application.DTOs.Subjects;
using Academic.Application.Interfaces;
using Academic.Application.Utilities;
using Academic.Core.Entities;
using Academic.Core.Interfaces;
using Academic.Infrastructure.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Services
{
    public class CourseSubjectsService : ICourseSubjectService
    {
        private readonly IUnitOfWork<CourseSubject> unitOfWork;
        private readonly IUnitOfWork<Subject>subjectUnitOfWork;
        private readonly IMapper mapper;

        public CourseSubjectsService(IUnitOfWork<CourseSubject> unitOfWork, IMapper mapper, IUnitOfWork<Subject> subjectUnitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.subjectUnitOfWork = subjectUnitOfWork;
        }

        public async Task<APIResponseResult<bool>> AddCourseSubjects(CourseSubjectsDTO courseSubjectsDTO)
        {
            var courseSubject = new CourseSubject() { CourseId = courseSubjectsDTO.CourseId, SubjectId = courseSubjectsDTO.SubjectId };
            await unitOfWork.Entity.InsertAsync(courseSubject);
            await unitOfWork.SaveAsync();

            return new APIResponseResult<bool>(true, "CourseSubject is added successfully");
        }

        public async Task<APIResponseResult<bool>> DeletecourseSubject(int CourseId, int SubjectId)
        {
            var courseSubject = unitOfWork.Element.GetElement(s => s.CourseId == CourseId && s.SubjectId == SubjectId, null);

            if (courseSubject is null)
                return new APIResponseResult<bool>(false, "StudentPhone is not found");

            unitOfWork.Element.DeleteElement(courseSubject);
            await unitOfWork.SaveAsync();

            return new APIResponseResult<bool>(true, "CourseSubject is deleted successfully");
        }

        public async Task<APIResponseResult<IEnumerable<CourseSubjectsDTO>>> GetAllCourseSubjects()
        {
            var CourseSubjects = await unitOfWork.Entity.GetAllAsync();
            var CourseSubjectDTOs = new List<CourseSubjectsDTO>();
            if (CourseSubjects is null)
                return new APIResponseResult<IEnumerable<CourseSubjectsDTO>>(null, "CourseSubjects are not found");
            foreach (var student in CourseSubjects)
            {
                CourseSubjectsDTO dto = mapper.Map<CourseSubjectsDTO>(student);

                CourseSubjectDTOs.Add(dto);

            }
            return new APIResponseResult<IEnumerable<CourseSubjectsDTO>>(CourseSubjectDTOs, "All CourseSubjects are Retrieved Successfully");

        }

        public async Task<APIResponseResult<IEnumerable<SubjectDTO>>> GetAllCourseSubjectsByCourseId(int CourseId)
        {
            var CourseSubjects = unitOfWork.Element.GetElements(s => s.CourseId == CourseId, "Subject");
            var CourseSubjectDTOs = new List<SubjectDTO>();
            if (CourseSubjects is null)
                return new APIResponseResult<IEnumerable<SubjectDTO>>(null, "CourseSubjects are not found");
            foreach (var cs in CourseSubjects)
            {
                var subject = await subjectUnitOfWork.Entity.GetByIdAsync(cs.SubjectId);
                SubjectDTO dto = mapper.Map<SubjectDTO>(subject);
                CourseSubjectDTOs.Add(dto);

            }
            return new APIResponseResult<IEnumerable<SubjectDTO>>(CourseSubjectDTOs, "All CourseSubjects are Retrieved Successfully");

        }


     

            public async Task<APIResponseResult<CourseSubjectsDTO>> GetCourseSubjectsById(int CourseId, int SubjectId)
        {
            var courseSubject = unitOfWork.Element.GetElement(s => s.CourseId == CourseId && s.SubjectId == SubjectId, null);

            if (courseSubject == null)
                return new APIResponseResult<CourseSubjectsDTO>(null, "courseSubject is not found");

            var courseSubjectDTO = mapper.Map<CourseSubjectsDTO>(courseSubject);
            return new APIResponseResult<CourseSubjectsDTO>(courseSubjectDTO, "courseSubject is Retrieved Successfully");

        }

        public async Task<APIResponseResult<bool>> UpdatecourseSubject(CourseSubjectsDTO courseSubjectDTO)
        {
            var CourseSubjects = new CourseSubject() { CourseId = courseSubjectDTO.CourseId, SubjectId = courseSubjectDTO.SubjectId};
            await unitOfWork.Entity.UpdateAsync(CourseSubjects);
            await unitOfWork.SaveAsync();

            return new APIResponseResult<bool>(true, "CourseSubject is Updated successfully");
        }
    }
}
