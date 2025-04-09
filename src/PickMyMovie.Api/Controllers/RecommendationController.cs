using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickMyMovie.Application.DTOs;
using PickMyMovie.Domain.Interfaces;

namespace PickMyMovie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly IMovieRecommendationService _service;

        public RecommendationController(IMovieRecommendationService service)
        {
            _service = service;
        }

        [HttpPost("recommend")]
        public async Task<ActionResult<List<MovieRecommendationDto>>> RecommendMovies([FromBody] RecommendationRequestDto request)
        {
            if (request.SelectedPreferenceIds == null || !request.SelectedPreferenceIds.Any())
                return BadRequest("No preferences selected.");

            var result = await _service.RecommendAsync(request.SelectedPreferenceIds);
            return Ok(result);
        }
    }
}
