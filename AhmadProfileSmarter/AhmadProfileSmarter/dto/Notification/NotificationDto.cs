namespace AhmadProfileSmarter.dto.Notification
{
    public class NotificationDto
    {
       

        public string title { get; set; }

        public string message { get; set; }

        public string? notificationType { get; set; }

        public int senderId { get; set; }

        public int receiverId { get; set; }
    }
}
