namespace AhmadService.dto.Chats
{
    public class ChatsDto
    {
        public int ChatID { get; set; }

        public string? ChatText { get; set; }

        public int SenderID { get; set; }

        public int ReceiverID { get; set; }

        public DateTime MessageDate { get; set; }
    }
}
