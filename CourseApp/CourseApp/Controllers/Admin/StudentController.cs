using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Groups;
using Service.DTOs.Admin.Students;
using Service.Services.Interfaces;

namespace CourseApp.Controllers.Admin
{
  
    public class StudentController : BaseController
    {
        private readonly IGroupService _groupService;
        private readonly IStudentService _studentService;
        private readonly ILogger<GroupController> _logger;

        public StudentController(IGroupService groupService,
                                 ILogger<GroupController> logger,
                                 IStudentService studentService)
        {

            _logger = logger;
            _groupService = groupService;
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Get All method is working");

            return Ok(await _studentService.GetAllWithGroupsAsync());

        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] StudentCreateDto request)
        {

            await _studentService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), new { response = "Data successfully created" });

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _studentService.GetByIdAsync(id));

        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null) return BadRequest();
            await _studentService.DeleteAsync((int)id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] StudentEditDto request)
        {
            await _studentService.EditAsync(id, request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> SearchByNameOrSurname([FromQuery] string nameOrSurname)
        {
            _logger.LogInformation("Search method is working");
            var data = await _studentService.SearchByNameOrSurname(nameOrSurname);
            return Ok(data);

        }
    }
}
