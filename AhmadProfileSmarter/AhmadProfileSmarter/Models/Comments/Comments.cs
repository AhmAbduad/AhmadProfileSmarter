using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmadDAL.Models.Comments
{
    [Table("Comments")]
    public class Comments
    {
        [Key]
        public int CommentsID { get; set; }

        // 🔑 Foreign Key
        [Required]
        public int TaskID { get; set; }

        [Required]
        [StringLength(800)]
        public string CommentsText { get; set; } = string.Empty;

        // 🔗 Navigation Property
        [ForeignKey(nameof(TaskID))]
        public Tasks.Tasks? Task { get; set; }
    }
}
