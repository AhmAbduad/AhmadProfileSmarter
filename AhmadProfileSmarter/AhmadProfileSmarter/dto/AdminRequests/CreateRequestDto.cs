namespace AhmadService.dto.AdminRequests
{
    public class CreateRequestDto
    {

        public int UserId { get; set; }

        public string? RequestType { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string Status { get; set; } = "Pending";

        public string? AdminRemarks { get; set; }
        
    }
}
