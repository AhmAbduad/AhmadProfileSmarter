namespace AhmadService.dto.MeetingsVideo
{
    public class MeetingsVideoDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CreatedBy { get; set; }
        public string? MeetingLink { get; set; }
        public int TaskID { get; set; }

        // ✅ Add selected users
        public List<int> Users { get; set; } = new List<int>();
    }

    public class MeetingParticipantDto
    {
        public int UserID { get; set; }
        public bool IsHost { get; set; }
        public string UserName { get; set; } = string.Empty;
    }

    public class MeetingDto
    {
        public int MeetingID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string MeetingLink { get; set; } = string.Empty;
        public List<MeetingParticipantDto> Participants { get; set; } = new();
    }
}
