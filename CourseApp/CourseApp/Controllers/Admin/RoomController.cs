using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Rooms;
using Service.DTOs.Admin.Teachers;
using Service.Services.Interfaces;

namespace CourseApp.Controllers.Admin
{
   
    public class RoomController : BaseController
    {
        private readonly IRoomService _roomService;
        private readonly ILogger<RoomController> _logger;

        public RoomController(IRoomService roomService,
                              ILogger<RoomController> logger)
        {
            _roomService = roomService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Get All method is working");
            var data = await _roomService.GetAllWithAsync();
            return Ok(data);

        }
        [HttpGet]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            _logger.LogInformation("Search method is working");
            var data = await _roomService.SearchtByName(name);
            return Ok(data);

        }
      
       
        [HttpPost]

        public async Task<IActionResult> Create([FromBody] RoomCreateDto request)
        {

            await _roomService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), new { response = "Data successfully created" });

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _roomService.GetByIdAsync(id));

        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null) return BadRequest();
            await _roomService.DeleteAsync((int)id);

            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] RoomEditDto request)
        {
            await _roomService.EditAsync(id, request);
            return Ok();
        }
    }
}
