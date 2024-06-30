using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Groups;
using Service.DTOs.Admin.Teachers;
using Service.Services;
using Service.Services.Interfaces;

namespace CourseApp.Controllers.Admin
{
   
    public class TeacherController : BaseController
    {
        private readonly ITeacherService _teacherService;
        private readonly ILogger<TeacherController> _logger;
        private readonly IGroupService _groupService;

        public TeacherController(ITeacherService teacherService,
                              ILogger<TeacherController> logger,
                              IGroupService groupService)
        {
            _teacherService = teacherService;
            _logger = logger;
            _groupService = groupService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Get All method is working");

            return Ok(await _teacherService.GetAllWithAsync());

        }
        [HttpGet]
        public async Task<IActionResult> SearchByNameOrSurname([FromQuery] string str)
        {
            _logger.LogInformation("Search method is working");
            var data = await _teacherService.SearchByNameOrSurname(str);
            return Ok(data);

        }

       

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] TeacherCreateDto request)
        {
            await _teacherService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), new { response = "Data successfully created" });           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _teacherService.GetByIdAsync(id));

        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null) return BadRequest();
            await _teacherService.DeleteAsync((int)id);

            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] TeacherEditDto request)
        {
            await _teacherService.EditAsync(id, request);
            return Ok();
        }
    }
}
