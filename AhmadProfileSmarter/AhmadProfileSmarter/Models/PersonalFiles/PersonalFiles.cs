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

        public byte[]? ActualFile { get; set; }

        [MaxLength(300)]
        public string? Size { get; set; }

        public DateTime? UploadDate { get; set; }
    }
}
