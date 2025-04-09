using PickMyMovie.Application.DTOs;
using PickMyMovie.Domain.Interfaces;
using System;

namespace PickMyMovie.Application.Services
{
    public class MovieRecommendationService : IMovieRecommendationService
    {
        private readonly PickMyMovieDbContext _context;

        public MovieRecommendationService(PickMyMovieDbContext context)
        {
            _context = context;
        }

        public async Task<List<MovieRecommendationDto>> RecommendAsync(List<int> preferenceIds)
        {
            var matchingRules = await _context.Rules
                .Include(r => r.Movie)
                .Include(r => r.Preference)
                .Where(r => preferenceIds.Contains(r.PreferenceId))
                .ToListAsync();

            return matchingRules
                .GroupBy(r => r.Movie)
                .Select(g => new MovieRecommendationDto
                {
                    Title = g.Key.Title,
                    Description = g.Key.Description,
                    Justifications = g.Select(r => r.Justification).Distinct().ToList()
                })
                .ToList();
        }
    }
}
