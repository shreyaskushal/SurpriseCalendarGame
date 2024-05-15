using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurpriseCalendarAPI.Dtos;
using SurpriseCalendarAPI.Services.Interfaces;

namespace SurpriseCalendarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurpriseCalendarController : ControllerBase
    {
        private readonly ISurpriseCalendarService _service;

        public SurpriseCalendarController(ISurpriseCalendarService service)
        {
            _service = service;
        }

        [HttpGet("open-squares")]
        public async Task<ActionResult<List<SquareDto>>> GetOpenSquares()
        {
            var openSquares = await _service.GetOpenSquaresAsync();
            return Ok(openSquares);
        }

        [HttpPost("scratch")]
        public async Task<ActionResult<SquareDto>> ScratchSquare([FromBody] ScratchSquareDto scratchSquareDto)
        {
            try
            {
                var scratchedSquare = await _service.ScratchSquareAsync(scratchSquareDto);
                return Ok(scratchedSquare);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred.", Details = ex.Message });
            }
        }
    }
}
