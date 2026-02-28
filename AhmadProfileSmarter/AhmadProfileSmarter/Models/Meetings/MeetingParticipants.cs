using AhmadDAL.Models.Credentials;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmadDAL.Models.Meetings
{
    [Table("MeetingParticipants")]
    public class MeetingParticipants
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MeetingID { get; set; }

        [Required]
        public int UserID { get; set; }

        public bool IsHost { get; set; } = false;

        public DateTime? JoinedAt { get; set; }

        // Navigation properties (optional, if you want EF relationships)
        [ForeignKey(nameof(MeetingID))]
        public Meetings? Meeting { get; set; }


        [ForeignKey(nameof(UserID))]
        public User? User { get; set; }
    }
}
