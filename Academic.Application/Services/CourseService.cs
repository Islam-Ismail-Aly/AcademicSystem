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

        public async Task<ApiResponse> Delete(object Id)
        {
            try {
                await CourseUnitOfWork.Entity.DeleteAsync(Id);
                await CourseUnitOfWork.SaveAsync();
                return new ApiResponse(StatusCodes.Status201Created, "Course has been deleted");
            }
            catch(Exception ex)
            {
                return new ApiResponse(StatusCodes.Status500InternalServerError, "Somthing went wrong");
            }

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

        public async  Task<ApiResponse> Update(CourseDTO dto)
        {
            try { 
            Course course = mapper.Map<Course>(dto);
            await CourseUnitOfWork.Entity.UpdateAsync(course);
            await CourseUnitOfWork.SaveAsync();
                return new ApiResponse(StatusCodes.Status201Created, "Course has been Updated");
            }
            catch (Exception ex)
            {
                return new ApiResponse(StatusCodes.Status500InternalServerError, "Somthing went wrong");
            }

        }
    }
}
