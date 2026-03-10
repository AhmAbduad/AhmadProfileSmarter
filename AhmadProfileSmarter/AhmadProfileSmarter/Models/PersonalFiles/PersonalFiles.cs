using AhmadDAL.Models.Credentials;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmadDAL.Models.PersonalFiles
{
    [Table("PersonalFiles")]
    public class PersonalFiles
    {
        [Key]
        public int PersonalFilesID { get; set; }

        [MaxLength(300)]
        public string? ActualFileName { get; set; }

        [Required]
        public int UserID { get; set; }   // 🔑 Foreign Key

        public byte[]? ActualFile { get; set; }

        [MaxLength(300)]
        public string? Size { get; set; }

        public DateTime? UploadDate { get; set; }



        [Required]
        public string ContentType { get; set; }

        [ForeignKey(nameof(UserID))]
        public User User { get; set; }
    }
}
