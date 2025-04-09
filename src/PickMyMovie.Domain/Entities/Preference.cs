namespace PickMyMovie.Domain.Entities
{
    public class Preference
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public List<Rule> Rules { get; set; }
    }
}
