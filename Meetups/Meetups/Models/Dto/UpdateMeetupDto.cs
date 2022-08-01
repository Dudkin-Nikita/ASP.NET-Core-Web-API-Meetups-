namespace Meetups.Models.Dto
{
    public class UpdateMeetupDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Plan { get; set; } = string.Empty;
        public string Speeker { get; set; } = string.Empty;
        public string Organizer { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
