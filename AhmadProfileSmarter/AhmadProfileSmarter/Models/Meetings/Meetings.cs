using AhmadDAL.Models.Credentials;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmadDAL.Models.Meetings
{
    [Table("Meetings")]
    public class Meetings
    {
        [Key]
        public int MeetingID { get; set; }

        

        [Required]
        [StringLength(300)]
        public string? Title { get; set; }

        [Required]
        [StringLength(300)]
        public string? Description { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

       

        [Required]
        public string? MeetingLink { get; set; }


        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public bool IsDeleted { get; set; }



        // 🔑 Foreign Key
        [Required]
        public int TaskID { get; set; }

        [Required]
        public int CreatedBy { get; set; }


        // 🔗 Navigation Property
        [ForeignKey(nameof(TaskID))]
        public Tasks.Tasks? Task { get; set; }


        [ForeignKey(nameof(CreatedBy))]
        public User? User { get; set; }

        public ICollection<MeetingParticipants> MeetingPart { get; set; } = new List<MeetingParticipants>();
    }
}
