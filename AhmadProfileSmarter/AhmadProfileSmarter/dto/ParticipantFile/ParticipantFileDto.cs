namespace AhmadService.dto.ParticipantFile
{
    public class ParticipantFileDto
    {

        public string? ActualFileName { get; set; }

        public IFormFile? File { get; set; }   // ✅ Correct way

        public string? Size { get; set; }

        public DateTime? UploadDate { get; set; }

        public int UserID { get; set; }


    }
}
