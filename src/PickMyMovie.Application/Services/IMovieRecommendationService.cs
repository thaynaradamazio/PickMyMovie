
using PickMyMovie.Application.DTOs;

namespace PickMyMovie.Domain.Interfaces
{
    public interface IMovieRecommendationService
    {
        Task<List<MovieRecommendationDto>> RecommendAsync(List<int> preferenceIds);
    }
}
