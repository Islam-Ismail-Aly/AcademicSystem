using Academic.Application.DTOs.SubjectDTOs;
using Academic.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "AcademicSystemAPIv1")]
    public class SubjectController : ControllerBase
    {
        private readonly IService<SubjectDTO> service;
        public SubjectController(IService<SubjectDTO>service)
        {
            this.service = service;
        }

        [HttpGet]
        public Task <IEnumerable<SubjectDTO>> Get()
        {
            var subjectDTOs =  service.GetAll();
            return (subjectDTOs);
        }

    }
}
