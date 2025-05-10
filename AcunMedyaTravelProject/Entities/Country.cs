namespace AcunMedyaTravelProject.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public List<Destination> Destinations { get; set; }

    }
}