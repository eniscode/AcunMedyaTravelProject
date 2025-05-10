namespace AcunMedyaTravelProject.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
    }
}
