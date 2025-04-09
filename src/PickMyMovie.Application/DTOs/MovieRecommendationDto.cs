namespace PickMyMovie.Application.DTOs
{
    public class MovieRecommendationDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Justifications { get; set; }
    }
}
