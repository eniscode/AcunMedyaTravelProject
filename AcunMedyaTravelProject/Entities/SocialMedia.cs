namespace AcunMedyaTravelProject.Entities
{
    public class SocialMedia
    {
        public int Id { get; set; }

        public int GuideId { get; set; }
        public Guide Guide { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
    }
}
