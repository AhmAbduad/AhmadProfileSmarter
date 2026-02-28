using AhmadDAL.Models.Credentials;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmadDAL.Models.Chats
{
    [Table("Chats")]
    public class Chats
    {
        [Key]
        public int ChatID { get; set; }

        [Required]
        public int SenderID { get; set; }

        [Required]
        public int ReceiverID { get; set; }

        [Required]
        public string ChatText { get; set; } = string.Empty;

        [Required]
        public DateTime MessageDate { get; set; }

        // =============================
        // Navigation Properties
        // =============================

        [ForeignKey(nameof(SenderID))]
        public User? Sender { get; set; }

        [ForeignKey(nameof(ReceiverID))]
        public User? Receiver { get; set; }
    }
}
