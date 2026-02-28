using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmadDAL.Models.Attachment
{
    [Table("Attachment")]
    public class Attachment
    {
        [Key]
        public int AttachmentID { get; set; }

        // 🔑 Foreign Key
        [Required]
        public int TaskID { get; set; }

        [Required]
        public byte[] AttachmentFile { get; set; } = Array.Empty<byte>();

        [Required]
        [StringLength(200)]
        public string Size { get; set; } = string.Empty;

        [Required]
        public DateTime UploadDate { get; set; }


        [Required]
        public string FileName { get; set; }

        [Required]
        public string ContentType { get; set; }

        // 🔗 Navigation Property
        [ForeignKey(nameof(TaskID))]
        public Tasks.Tasks? Task { get; set; }
    }
}
