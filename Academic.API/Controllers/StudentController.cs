using Academic.Application.DTOs.Student;
using Academic.Application.Interfaces;
using Academic.Application.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Academic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [SwaggerTag("Student Management")]
    [ApiExplorerSettings(GroupName = "AcademicSystemAPIv1")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService service;
        public StudentController(IStudentService service)
        {
            this.service=service;
        }
        [HttpGet("GetAllStudents")]
        [SwaggerOperation(Summary =StudentControllerSwaggerAttributes.GetAllStudentSummary )]
        [SwaggerResponse(200, StudentControllerSwaggerAttributes.GetAllStudentResponse200, typeof(APIResponseResult<IEnumerable<StudentDTO>>))]
        [SwaggerResponse(404, StudentControllerSwaggerAttributes.GetAllStudentResponse404)]
        public async Task<ActionResult<APIResponseResult<IEnumerable<StudentDTO>>>> GetAllStudents()
        {
            var result = await service.GetAllStudentsAsync();

            if (!result.Success)
                return StatusCode(404, result);

            return Ok(result);
        }

        [HttpGet("GetStudent/{id:int}")]
        [SwaggerOperation(Summary = StudentControllerSwaggerAttributes.GetStudentByIdSummary)]
        [SwaggerResponse(200, StudentControllerSwaggerAttributes.GetStudentByIdResponse200, typeof(APIResponseResult<BranchDTO>))]
        [SwaggerResponse(404, StudentControllerSwaggerAttributes.GetStudentByIdResponse404)]
        public async Task<ActionResult<APIResponseResult<StudentDTO>>> GetStudent(int id)
        {
            var result = await service.GetStudentByIdAsync(id);

            if (!result.Success)
                return StatusCode(404, result);

            return Ok(result);
        }
        [HttpPost("CreateStudent")]
        [SwaggerOperation(Summary = StudentControllerSwaggerAttributes.AddStudentSummary)]
        [SwaggerResponse(201, StudentControllerSwaggerAttributes.AddStudentResponse201, typeof(APIResponseResult<bool>))]
        [SwaggerResponse(400, StudentControllerSwaggerAttributes.AddStudentResponse400)]
        public async Task<ActionResult<APIResponseResult<bool>>> CreateStudent([FromBody] StudentDTO studentDTO)
        {
            var result = await service.AddStudentAsync(studentDTO);

            if (!result.Success)
                return StatusCode(404, result);

            return CreatedAtAction(nameof(GetStudent), new { id = studentDTO.Id }, result);
        }
        [HttpPut("UpdateStudent/{id:int}")]
        [SwaggerOperation(Summary = StudentControllerSwaggerAttributes.UpdateStudentSummary)]
        [SwaggerResponse(204, StudentControllerSwaggerAttributes.UpdateStudentResponse204)]
        [SwaggerResponse(400, StudentControllerSwaggerAttributes.UpdateStudentResponse400)]
        [SwaggerResponse(404, StudentControllerSwaggerAttributes.UpdateStudentResponse404)]
        public async Task<ActionResult<APIResponseResult<bool>>> UpdateStudent(int id, [FromBody] StudentDTO studentDTO)
        {
            if (id != studentDTO.Id)
                return BadRequest(new APIResponseResult<bool>(false, "Invalid ID"));
            studentDTO.Id=id;
            var result = await service.UpdateStudentAsync(studentDTO);

            if (!result.Success)
                return StatusCode(404, result);

            return NoContent();
        }
        [HttpDelete("DeleteStudent/{id:int}")]
        [SwaggerOperation(Summary = StudentControllerSwaggerAttributes.DeleteStudentSummary)]
        [SwaggerResponse(204, StudentControllerSwaggerAttributes.DeleteStudentResponse204)]
        [SwaggerResponse(404, StudentControllerSwaggerAttributes.DeleteStudentResponse404)]
        public async Task<ActionResult<APIResponseResult<bool>>> DeleteStudent(int id)
        {
            var result = await service.DeleteStudentAsync(id);

            if (!result.Success)
                return StatusCode(404, result);

            return NoContent();
        }






    }
}
