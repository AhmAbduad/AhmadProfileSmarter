using AhmadDAL.Models.Credentials;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmadDAL.Models.AIChatMessage
{
    [Table("AIChatMessages")]
    public class AIChatMessage
    {
        [Key]
        public int MessageId { get; set; }

        [Required]
        [StringLength(1000)]
        public string MessageText { get; set; } = null!;

        
    }
}
