using Academic.Application.Constants;
using Academic.Application.DTOs.CourseSubjects;
using Academic.Application.DTOs.StudentPhones;
using Academic.Application.DTOs.Subjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [SwaggerTag("CourseSubject Management")]
    [ApiExplorerSettings(GroupName = "AcademicSystemAPIv1")]
    //[Authorize(Roles = "CourseSubject")]

    public class CourseSubjectController : ControllerBase
    {
        private readonly ICourseSubjectService service;
        public CourseSubjectController(ICourseSubjectService service)
        {
            this.service = service;
        }
        [HttpGet("GetAllCourseSubjects")]
        [SwaggerOperation(Summary = CourseSubjectControllerSwaggerAttribute.GetAllCourseSubjectSummary)]
        [SwaggerResponse(200, CourseSubjectControllerSwaggerAttribute.GetAlCourseSubjectResponse200, typeof(APIResponseResult<IEnumerable<CourseSubjectsDTO>>))]
        [SwaggerResponse(404, CourseSubjectControllerSwaggerAttribute.GetAllCourseSubjectResponse404)]
        public async Task<ActionResult<APIResponseResult<IEnumerable<CourseSubjectsDTO>>>> GetAllCourseSubjects()
        {
            var result = await service.GetAllCourseSubjects();

            if (!result.Success)
                return StatusCode(404, result);

            return Ok(result);
        }

        [HttpGet("GetAllCourseSubjectsOfCourse/{courseId:int}")]
        [SwaggerOperation(Summary = CourseSubjectControllerSwaggerAttribute.GetAllCourseSubjectSummary)]
        [SwaggerResponse(200, CourseSubjectControllerSwaggerAttribute.GetAlCourseSubjectResponse200, typeof(APIResponseResult<IEnumerable<CourseSubjectsDTO>>))]
        [SwaggerResponse(404, CourseSubjectControllerSwaggerAttribute.GetAllCourseSubjectResponse404)]
        public async Task<ActionResult<APIResponseResult<IEnumerable<SubjectDTO>>>> GetAllCourseSubjectsByCourseId(int courseId)
        {
            var result = await service.GetAllCourseSubjectsByCourseId(courseId);
           
            if (!result.Success)
                return StatusCode(404, result);

            return Ok(result);
        }

       

        [HttpGet("GetCourseSubject/{courseId:int}/{subjectId:int}")]
        [SwaggerOperation(Summary = StudentPhoneControllerSwaggerAttributes.GetStudentPhoneByIdSummary)]
        [SwaggerResponse(200, StudentPhoneControllerSwaggerAttributes.GetStudentPhoneByIdResponse200, typeof(APIResponseResult<CourseSubjectsDTO>))]
        [SwaggerResponse(404, StudentPhoneControllerSwaggerAttributes.GetStudentPhoneByIdResponse404)]
        public async Task<ActionResult<APIResponseResult<CourseSubjectsDTO>>> GetCourseSubject(int courseId, int subjectId)
        {
            var result = await service.GetCourseSubjectsById(courseId,subjectId);

            if (!result.Success)
                return StatusCode(404, result);

            return Ok(result);
        }

        [HttpPost("CreateCourseSubject")]
        [SwaggerOperation(Summary = CourseSubjectControllerSwaggerAttribute.AddCourseSubjectSummary)]
        [SwaggerResponse(201, CourseSubjectControllerSwaggerAttribute.AddCourseSubjectResponse201, typeof(APIResponseResult<bool>))]
        [SwaggerResponse(400, CourseSubjectControllerSwaggerAttribute.AddCourseSubjectResponse400)]
        public async Task<ActionResult<APIResponseResult<bool>>> CreateCourseSubject([FromBody] CourseSubjectsDTO CourseSubjectDTO)
        {
            var result = await service.AddCourseSubjects(CourseSubjectDTO);

            if (!result.Success)
                return StatusCode(404, result);

            return CreatedAtAction(nameof(GetCourseSubject), new { courseId = CourseSubjectDTO.CourseId, subjectId=CourseSubjectDTO.SubjectId }, result);
        }

        [HttpPut("UpdateCourseSubject/{courseId:int}/{subjectId:int}")]
        [SwaggerOperation(Summary = CourseSubjectControllerSwaggerAttribute.UpdateCourseSubjectSummary)]
        [SwaggerResponse(204, CourseSubjectControllerSwaggerAttribute.UpdateCourseSubjectResponse204)]
        [SwaggerResponse(400, CourseSubjectControllerSwaggerAttribute.UpdateCourseSubjectResponse400)]
        [SwaggerResponse(404, CourseSubjectControllerSwaggerAttribute.UpdateCourseSubjectResponse404)]
        public async Task<ActionResult<APIResponseResult<bool>>> UpdateCourseSubject(int courseId, int subjectId, [FromBody] CourseSubjectsDTO courseSubjectsDTO)
        {
            if (courseId == 0 || courseId != courseSubjectsDTO.CourseId)
                return NotFound();
            var result = await service.UpdatecourseSubject(courseSubjectsDTO);

            if (!result.Success)
                return StatusCode(404, result);

            return NoContent();
        }

        [HttpDelete("DeleteCourseSubject/{courseId:int}/{subjectId:int}")]
        [SwaggerOperation(Summary = CourseSubjectControllerSwaggerAttribute.DeleteCourseSubjectSummary)]
        [SwaggerResponse(204, CourseSubjectControllerSwaggerAttribute.DeleteCourseSubjectResponse204)]
        [SwaggerResponse(404, CourseSubjectControllerSwaggerAttribute.DeleteCourseSubjectResponse404)]
        public async Task<ActionResult<APIResponseResult<bool>>> DeleteStudentPhone(int courseId,int subjectId)
        {

            var result = await service.DeletecourseSubject(courseId,subjectId);

            if (!result.Success)
                return StatusCode(404, result);

            return NoContent();
        }
    }
}
