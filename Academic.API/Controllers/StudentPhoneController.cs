using Academic.Application.DTOs.Student;
using Academic.Application.DTOs.StudentPhones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [SwaggerTag("StudentPhone Management")]
    [ApiExplorerSettings(GroupName = "AcademicSystemAPIv1")]
    //[Authorize(Roles = "Students")]
    public class StudentPhoneController : ControllerBase
    {
        private readonly IStudentPhoneService service;
        public StudentPhoneController(IStudentPhoneService service)
        {
            this.service = service;
        }
        [HttpGet("GetAllStudentPhonesByStudentId/{studentId:int}")]
        [SwaggerOperation(Summary = StudentPhoneControllerSwaggerAttributes.GetAllStudentPhoneSummary)]
        [SwaggerResponse(200, StudentPhoneControllerSwaggerAttributes.GetAllStudentPhoneResponse200, typeof(APIResponseResult<IEnumerable<StudentPhonesDTO>>))]
        [SwaggerResponse(404, StudentPhoneControllerSwaggerAttributes.GetAllStudentPhoneResponse404)]
        public async Task<ActionResult<APIResponseResult<IEnumerable<StudentPhonesDTO>>>> GetAllStudentPhonesByStudentId(int studentId)
        {
            var result = await service.GetAllStudentPhonesByStudentId(studentId);

            if (!result.Success)
                return StatusCode(404, result);

            return Ok(result);
        }

        [HttpGet("GetAllStudentPhones")]
        [SwaggerOperation(Summary = StudentPhoneControllerSwaggerAttributes.GetAllStudentPhoneSummary)]
        [SwaggerResponse(200, StudentPhoneControllerSwaggerAttributes.GetAllStudentPhoneResponse200, typeof(APIResponseResult<IEnumerable<StudentPhonesDTO>>))]
        [SwaggerResponse(404, StudentPhoneControllerSwaggerAttributes.GetAllStudentPhoneResponse404)]
        public async Task<ActionResult<APIResponseResult<IEnumerable<StudentPhonesDTO>>>> GetAllStudentPhones()
        {
            var result = await service.GetAllStudentPhone();

            if (!result.Success)
                return StatusCode(404, result);

            return Ok(result);
        }

        [HttpGet("GetStudentPhone/{id:int}/{Phone}")]
        [SwaggerOperation(Summary = StudentPhoneControllerSwaggerAttributes.GetStudentPhoneByIdSummary)]
        [SwaggerResponse(200, StudentPhoneControllerSwaggerAttributes.GetStudentPhoneByIdResponse200, typeof(APIResponseResult<StudentPhonesDTO>))]
        [SwaggerResponse(404, StudentPhoneControllerSwaggerAttributes.GetStudentPhoneByIdResponse404)]
        public async Task<ActionResult<APIResponseResult<StudentPhonesDTO>>> GetStudentPhone(int id,string Phone)
        {
            var result = await service.GetStudentPhoneById(id,Phone);

            if (!result.Success)
                return StatusCode(404, result);

            return Ok(result);
        }

        [HttpPost("CreateStudentPhone")]
        [SwaggerOperation(Summary = StudentPhoneControllerSwaggerAttributes.AddStudentPhoneSummary)]
        [SwaggerResponse(201, StudentPhoneControllerSwaggerAttributes.AddStudentPhoneResponse201, typeof(APIResponseResult<bool>))]
        [SwaggerResponse(400, StudentPhoneControllerSwaggerAttributes.AddStudentPhoneResponse400)]
        public async Task<ActionResult<APIResponseResult<bool>>> CreateStudentPhone([FromBody] StudentPhonesDTO studentPhoneDTO)
        {
            var result = await service.AddStudentPhone(studentPhoneDTO);

            if (!result.Success)
                return StatusCode(404, result);

            return CreatedAtAction(nameof(GetStudentPhone), new { id = studentPhoneDTO.StudentId,phone=studentPhoneDTO.Phone }, result);
        }

        [HttpPut("UpdateStudentPhone/{id:int}/{Phone}")]
        [SwaggerOperation(Summary = StudentPhoneControllerSwaggerAttributes.UpdateStudentPhoneSummary)]
        [SwaggerResponse(204, StudentPhoneControllerSwaggerAttributes.UpdateStudentPhoneResponse204)]
        [SwaggerResponse(400, StudentPhoneControllerSwaggerAttributes.UpdateStudentPhoneResponse400)]
        [SwaggerResponse(404, StudentPhoneControllerSwaggerAttributes.UpdateStudentPhoneResponse404)]
        public async Task<ActionResult<APIResponseResult<bool>>> UpdateStudentPhone(int id,string Phone, [FromBody] StudentPhonesDTO studentPhoneDTO)
        {
            if(id == 0||id!=studentPhoneDTO.StudentId)
                return NotFound();
            var result = await service.UpdateStudentPhone(studentPhoneDTO);

            if (!result.Success)
                return StatusCode(404, result);

            return NoContent();
        }

        [HttpDelete("DeleteStudentPhone/{id:int}/{Phone}")]
        [SwaggerOperation(Summary = StudentPhoneControllerSwaggerAttributes.DeleteStudentPhoneSummary)]
        [SwaggerResponse(204, StudentPhoneControllerSwaggerAttributes.DeleteStudentPhoneResponse204)]
        [SwaggerResponse(404, StudentPhoneControllerSwaggerAttributes.DeleteStudentPhoneResponse404)]
        public async Task<ActionResult<APIResponseResult<bool>>> DeleteStudentPhone(int id,string Phone)
        {
            
            var result = await service.DeleteStudentPhone(id,Phone);

            if (!result.Success)
                return StatusCode(404, result);

            return NoContent();
        }

    }
}
