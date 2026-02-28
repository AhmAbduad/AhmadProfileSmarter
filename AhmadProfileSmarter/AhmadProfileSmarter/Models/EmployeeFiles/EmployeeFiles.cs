using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmadDAL.Models.EmployeeFiles
{
    [Table("EmployeeFiles")]
    public class EmployeeFiles
    {
        [Key]
        public int EmployeeFilesID { get; set; }

        [MaxLength(300)]
        public string? ActualFileName { get; set; }

        public byte[]? ActualFile { get; set; }

        [MaxLength(300)]
        public string? Size { get; set; }

        public DateTime? UploadDate { get; set; }
    }
}
