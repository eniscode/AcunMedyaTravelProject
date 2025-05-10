namespace AcunMedyaTravelProject.Entities
{
    public class Guide
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }

    }
}
