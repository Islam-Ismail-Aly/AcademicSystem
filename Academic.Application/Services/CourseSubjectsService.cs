using Academic.Application.DTOs.CourseSubjects;
using Academic.Application.DTOs.SubjectDTOs;
using Academic.Application.Interfaces;
using Academic.Application.Utilities;
using Academic.Core.Entities;
using Academic.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Services
{
    public class CourseSubjectsService : IService<CourseSubjectsDTO>
    {
        private readonly IUnitOfWork<CourseSubject> unitOfWork;
        private readonly IMapper mapper;

        public CourseSubjectsService(IUnitOfWork<CourseSubject> unitOfWork, IMapper mapper)
        {
            this.unitOfWork=unitOfWork;
            this.mapper=mapper;
            
        }
        public async Task<ApiResponse> Add(CourseSubjectsDTO dto)
        {
            CourseSubject subject = mapper.Map<CourseSubject>(dto);
            await unitOfWork.Entity.InsertAsync(subject);
            await unitOfWork.SaveAsync();
            return new ApiResponse(StatusCodes.Status201Created, "CourseSubject is created Successfully.");

        }

        public async Task Delete(object Id)
        {
            await unitOfWork.Entity.DeleteAsync(Id);
            await unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<CourseSubjectsDTO>> GetAll()
        {
            List<CourseSubject> courseSubjects = (List<CourseSubject>)await unitOfWork.Entity.GetAllAsync();
            List<CourseSubjectsDTO> courseSubjectsDTOs = new List<CourseSubjectsDTO>();
            if (courseSubjects == null)
            {
                return null;
            }
            else
            {
                foreach (var subject in courseSubjects)
                {
                    CourseSubjectsDTO dto = mapper.Map<CourseSubjectsDTO>(subject);
                    courseSubjectsDTOs.Add(dto);

                }
                return (courseSubjectsDTOs);
            }
        }

        public async Task<CourseSubjectsDTO> GetById(object Id, string? include)
        {
            CourseSubject subject = await unitOfWork.Entity.GetByIdAsync(Id);
            CourseSubjectsDTO dto = mapper.Map<CourseSubjectsDTO>(subject);
            return (dto);
        }

        public async Task Update(CourseSubjectsDTO dto)
        {
            CourseSubject subject = mapper.Map<CourseSubject>(dto);
            await unitOfWork.Entity.UpdateAsync(subject);
            await unitOfWork.SaveAsync();
        }
    }
}
