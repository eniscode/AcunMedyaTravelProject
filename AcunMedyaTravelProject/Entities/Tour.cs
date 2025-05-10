using AcunMedyaTravelProject.Enums;

namespace AcunMedyaTravelProject.Entities
{
    public class Tour
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int? Discount { get; set; }
        public TourCategory TourCategory { get; set; }
        public int? CityCount { get; set; }
        public int? TourPlaceCount { get; set; }
    }
}
