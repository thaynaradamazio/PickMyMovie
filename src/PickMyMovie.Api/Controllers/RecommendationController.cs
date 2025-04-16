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
            var preferenceIds = new List<int> { request.GenreId, request.MoodId, request.DurationId };

            var result = await _service.RecommendAsync(preferenceIds);
            return Ok(result);
        }

    }
}
