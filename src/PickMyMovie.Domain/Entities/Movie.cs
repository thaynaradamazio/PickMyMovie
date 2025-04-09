namespace PickMyMovie.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<Rule> Rules { get; set; }
    }

}
