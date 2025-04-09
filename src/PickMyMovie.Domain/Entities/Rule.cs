namespace PickMyMovie.Domain.Entities
{
    public class Rule
    {
        public int Id { get; set; }

        public int PreferenceId { get; set; }
        public Preference Preference { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public string Justification { get; set; }
    }
}
