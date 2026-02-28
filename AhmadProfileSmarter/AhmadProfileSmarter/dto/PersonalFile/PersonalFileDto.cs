namespace AhmadService.dto.PersonalFile
{   
    public class PersonalFileDto
    {
        public string? ActualFileName { get; set; }

        public IFormFile? File { get; set; }   // ✅ Correct way

        public string? Size { get; set; }

        public DateTime? UploadDate { get; set; }
    }
}
