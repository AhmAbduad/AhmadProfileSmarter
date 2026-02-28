namespace AhmadService.dto.Comment
{
    public class SubmitCommentDto
    {
        public int TaskID { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}
