using AhmadDAL.Models.Credentials;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmadDAL.Models.Notifications
{
    [Table("Notifications")]
    public class Notifications
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public string? NotificationType { get; set; }

        // 🔹 Foreign Key - Sender
        public int? SenderId { get; set; }
       

        // 🔹 Foreign Key - Receiver
        public int ReceiverId { get; set; }

        public bool IsRead { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;

        public User? Sender { get; set; }

        public User Receiver { get; set; } = null!;
    }
}
