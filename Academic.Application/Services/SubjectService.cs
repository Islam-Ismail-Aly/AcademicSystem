using Academic.Application.DTOs.Subjects;
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
    public class SubjectService : IService<SubjectDTO>
    {
        private readonly IUnitOfWork<Subject> SubjectUnitOfWork;
        private readonly IMapper mapper;

        public SubjectService(IUnitOfWork<Subject> SubjectUnitOfWork, IMapper mapper)
        {
            this.SubjectUnitOfWork=SubjectUnitOfWork;
            this.mapper=mapper;
        }
        public async Task<ApiResponse> Add(SubjectDTO dto)
        {
            Subject subject = new Subject() { Name=dto.Name,MinDegree=dto.MinDegree,MaxDegree=dto.MaxDegree};
            await SubjectUnitOfWork.Entity.InsertAsync(subject);
            await SubjectUnitOfWork.SaveAsync();
            return new ApiResponse(StatusCodes.Status201Created, "Subject is created Successfully.");
        }

        public async Task Delete(object Id)
        {
            await SubjectUnitOfWork.Entity.DeleteAsync(Id);
            await SubjectUnitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<SubjectDTO>> GetAll()
        {
            List<Subject> subjects = (List<Subject>)await SubjectUnitOfWork.Entity.GetAllAsync();
            List<SubjectDTO> SubjectDTOs = new List<SubjectDTO>();
            if (subjects == null)
            {
                return null;
            }
            else
            {
                foreach (var subject in subjects)
                {
                    SubjectDTO dto = mapper.Map<SubjectDTO>(subject);
                    dto.Id = subject.Id;
                    SubjectDTOs.Add(dto);

                }
                return (SubjectDTOs);
            }
        }

        public async Task<SubjectDTO> GetById(object Id, string? include)
        {
            Subject subject = await SubjectUnitOfWork.Entity.GetByIdAsync(Id);
            SubjectDTO dto = mapper.Map<SubjectDTO>(subject);
            dto.Id = subject.Id;
            return (dto);

        }

        public async Task Update(SubjectDTO dto)
        {
            Subject subject = new Subject() { Name = dto.Name, MinDegree = dto.MinDegree, MaxDegree = dto.MaxDegree };
            subject.Id=dto.Id;
            await SubjectUnitOfWork.Entity.UpdateAsync(subject);
            await SubjectUnitOfWork.SaveAsync();
        }
    }
}
