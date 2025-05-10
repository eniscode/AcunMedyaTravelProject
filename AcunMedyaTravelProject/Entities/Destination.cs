namespace AcunMedyaTravelProject.Entities
{
    public class Destination
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string CoverImageUrl { get; set; }
        public int CountryId { get; set; }
        public Country country { get; set; }
        public List<Package> Packages { get; set; }
    }
}
