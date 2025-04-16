using Microsoft.EntityFrameworkCore;
using PickMyMovie.Application.DTOs;
using PickMyMovie.Domain.Interfaces;
using PickMyMovie.Infrastructure.DataAccess;
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
            if (preferenceIds.Count != 3)
                throw new ArgumentException("You must select exactly 3 preferences: one for Genre, Mood, and Duration.");

            var matchingMovieIds = await _context.Rules
                .Where(r => preferenceIds.Contains(r.PreferenceId))
                .GroupBy(r => r.MovieId)
                .Where(g => g.Select(r => r.PreferenceId).Distinct().Count() == 3)
                .Select(g => g.Key)
                .ToListAsync();

            var movies = await _context.Movies
                .Where(m => matchingMovieIds.Contains(m.Id))
                .Select(m => new MovieRecommendationDto
                {
                    Title = m.Title,
                    Description = m.Description,
                    Justifications = _context.Rules
                        .Where(r => r.MovieId == m.Id && preferenceIds.Contains(r.PreferenceId))
                        .Select(r => r.Justification)
                        .ToList()
                })
                .ToListAsync();

            return movies;
        }

    }
}
