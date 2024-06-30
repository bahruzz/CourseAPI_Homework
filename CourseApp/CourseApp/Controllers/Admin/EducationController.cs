using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Educations;
using Service.DTOs.Admin.Rooms;
using Service.Services.Interfaces;

namespace CourseApp.Controllers.Admin
{
    public class EducationController :BaseController
    {
        private readonly IEducationService _educationService;
        private readonly ILogger<EducationController> _logger;

        public EducationController(IEducationService educationService,
                              ILogger<EducationController> logger)
        {
            _educationService = educationService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Get All method is working");
            var data = await _educationService.GetAllWithAsync();
            return Ok(data);

        }

        [HttpGet]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            _logger.LogInformation("Search method is working");
            var data = await _educationService.SearchByName(name);
            return Ok(data);

        }

    

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] EducationCreateDto request)
        {

            await _educationService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), new { response = "Data successfully created" });

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _educationService.GetByIdAsync(id));

        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null) return BadRequest();
            await _educationService.DeleteAsync((int)id);

            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] EducationEditDto request)
        {
            await _educationService.EditAsync(id, request);
            return Ok();
        }
    }
}
