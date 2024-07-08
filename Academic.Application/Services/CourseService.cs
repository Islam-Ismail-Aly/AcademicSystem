using Academic.Application.DTOs.Course;
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
    public class CourseService : IService<CourseDTO>
    {
        private readonly IUnitOfWork<Course> CourseUnitOfWork;
        private readonly IMapper mapper;

        public CourseService(IUnitOfWork<Course> CourseUnitOfWork, IMapper mapper)
        {
            this.CourseUnitOfWork=CourseUnitOfWork;
            this.mapper=mapper;
            
        }
        public async Task<ApiResponse> Add(CourseDTO dto)
        {
            Course course = new Course() { Name = dto.Name, Description = dto.Description, Price = dto.Price, TotalHours = dto.TotalHours };
            await CourseUnitOfWork.Entity.InsertAsync(course);
            await CourseUnitOfWork.SaveAsync();
            return new ApiResponse(StatusCodes.Status201Created, "Course is created Successfully.");
        }

        public async Task Delete(object Id)
        {
            await CourseUnitOfWork.Entity.DeleteAsync(Id);
            await CourseUnitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<CourseDTO>> GetAll()
        {
            List<Course> courses = (List<Course>)await CourseUnitOfWork.Entity.GetAllAsync();
            List<CourseDTO> CourseDTOs = new List<CourseDTO>();
            if (courses == null)
            {
                return null;
            }
            else
            {
                foreach (var course in courses)
                {
                    CourseDTO dto = mapper.Map<CourseDTO>(course);
                    dto.Id = course.Id;
                    CourseDTOs.Add(dto);

                }
                return (CourseDTOs);
            }
        }

        public async Task<CourseDTO> GetById(object Id, string? include)
        {
            Course course = await CourseUnitOfWork.Entity.GetByIdAsync(Id);
            CourseDTO dto = mapper.Map<CourseDTO>(course);
            dto.Id = course.Id;
            return (dto);
        }

        public async Task Update(CourseDTO dto)
        {
            Course course = new Course() { Id=dto.Id,Name = dto.Name, Description = dto.Description, Price = dto.Price, TotalHours = dto.TotalHours };
            await CourseUnitOfWork.Entity.UpdateAsync(course);
            await CourseUnitOfWork.SaveAsync();
        }
    }
}
