using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Groups;
using Service.Services.Interfaces;

namespace CourseApp.Controllers.Admin
{

    public class GroupController : BaseController
    {
        private readonly IGroupService _groupService;
        private readonly ILogger<GroupController> _logger;

        public GroupController(IGroupService groupService,
                              ILogger<GroupController> logger)
        {
            
            _logger = logger;
            _groupService = groupService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Get All method is working");

            return Ok(await _groupService.GetAllWithStudentCountAsync());

        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] GroupCreateDto request)
        {

            await _groupService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), new { response = "Data successfully created" });

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _groupService.GetByIdAsync(id));

        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null) return BadRequest();
            await _groupService.DeleteAsync((int)id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] GroupEditDto request)
        {
            await _groupService.EditAsync(id, request);
            return Ok();
        }
    }
}
