namespace AhmadService.dto.Reportbug
{
    public class ReportbugDto
    {

        public int UserId { get; set; }
        public string title { get; set; }

        public string description { get; set; }

        public IFormFile? attachment { get; set; }
    }
}
