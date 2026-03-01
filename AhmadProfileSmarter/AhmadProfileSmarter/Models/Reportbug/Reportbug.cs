using AhmadDAL.Models.Credentials;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmadDAL.Models.Reportbug
{
    [Table("Reportbug")]
    public class Reportbug
    {
        [Key]
        public int BugId { get; set; }

        [Required]
        [StringLength(100)]
        public string title { get; set; } = null!;

        [Required]
        [StringLength(255)]
        public string description { get; set; } = null!;

        //[Required]
        public byte[]? attachment { get; set; }


        [Required]
        public int UserId { get; set; }



        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
