namespace Academic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "AcademicSystemAPIv1")]
    //[Authorize(Roles = "Subjects")]
    public class SubjectController : ControllerBase
    {
        private readonly IService<SubjectDTO> service;
        public SubjectController(IService<SubjectDTO> service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var subjectDTOs = await service.GetAll();
            if (subjectDTOs == null)
                return Ok();

            return Ok(subjectDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> getById(int id)
        {
            SubjectDTO subjectDTO = await service.GetById(id, null);
            if (subjectDTO == null)
                return NotFound();

            return Ok(subjectDTO);
        }

        [HttpPost]
        [Route("subject")]
        public async Task<ApiResponse> Add(SubjectDTO subject)
        {
            var result = await service.Add(subject);
            return (result);
        }

        [HttpDelete("Delete")]

        public async Task<ActionResult> delete(int id)
        {
            var subject = await service.GetById(id, null);
            if (subject == null)
                return NotFound();
            await service.Delete(id);
            return Ok(subject);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> update(int id, SubjectDTO subjectDTO)
        {

            subjectDTO.Id = id;
            await service.Update(subjectDTO);
            return Ok(subjectDTO);
        }

    }
}
