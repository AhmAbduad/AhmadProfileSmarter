using AhmadDAL.DataAccessLayer.AdminRequests;
using AhmadDAL.Models.AdminRequests;
using AhmadDAL.Models.Chats;
using AhmadDAL.Models.Employees;
using AhmadDAL.Models.Meetings;
using AhmadDAL.Models.Notifications;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AhmadDAL.Models.Credentials
{

    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Email { get; set; } = null!;



        public ICollection<Employees.Employee> Employees { get; set; } = new List<Employees.Employee>();

        public ICollection<AhmadDAL.Models.Chats.Chats> SentChats { get; set; } = new List<AhmadDAL.Models.Chats.Chats>();
        
        public ICollection<AhmadDAL.Models.Chats.Chats> ReceivedChats { get; set; } = new List<AhmadDAL.Models.Chats.Chats>();

        public ICollection<AhmadDAL.Models.Meetings.Meetings> Meetings { get; set; } = new List<AhmadDAL.Models.Meetings.Meetings>();


        // 🔹 Navigation Properties
        public ICollection<AhmadDAL.Models.Notifications.Notifications> SentNotifications { get; set; }
            = new List<AhmadDAL.Models.Notifications.Notifications>();

        public ICollection<AhmadDAL.Models.Notifications.Notifications> ReceivedNotifications { get; set; }
            = new List<AhmadDAL.Models.Notifications.Notifications>();


        public ICollection<MeetingParticipants> MeetingPart { get; set; } = new List<MeetingParticipants>();

        public ICollection<AhmadDAL.Models.AdminRequests.AdminRequests> AdminRequests { get; set; } = new List<AhmadDAL.Models.AdminRequests.AdminRequests>();

    }
}
