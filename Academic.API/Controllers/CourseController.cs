using Academic.Application.DTOs.Course;
using Academic.Application.Interfaces;
using Academic.Application.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace Academic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Courses Management")]
    [ApiExplorerSettings(GroupName = "AcademicSystemAPIv1")]
    //[Authorize(Roles = "Courses")]
    public class CourseController : ControllerBase
    {
        private readonly IService<CourseDTO> service;
        public CourseController(IService<CourseDTO> service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var CourseDTOs = await service.GetAll();
            return Ok(CourseDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> getById(int id)
        {
            CourseDTO courseDTO = await service.GetById(id, null);
            if(courseDTO==null)
                return NotFound();
            return Ok(courseDTO);
        }

        [HttpPost]
        [Route("course")]
        public async Task<ActionResult> Add(CourseDTO courseDTO)
        {
            try
            {
                var result = await service.Add(courseDTO);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("Delete")]

        public async Task<ActionResult> delete(int id)
        {
            var course = await service.GetById(id, null);
            if (course == null)
                return NotFound();
            await service.Delete(id);
            return Ok(course);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> update(int id, CourseDTO courseDTO)
        {
            
            courseDTO.Id = id;
            await service.Update(courseDTO);
            return Ok(courseDTO);
        }
    }
}
