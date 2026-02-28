using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmadDAL.Models.Activity
{
    [Table("Activity")]
    public class Activity
    {
        [Key]
        public int ActivityID { get; set; }

        [Required]
        public int TaskID { get; set; }   // 🔑 Foreign Key

        [Required]
        [StringLength(800)]
        public string ActivityText { get; set; } = string.Empty;

        // 🔗 Navigation Property
        [ForeignKey(nameof(TaskID))]
        public Tasks.Tasks? Task { get; set; }
    }
}
