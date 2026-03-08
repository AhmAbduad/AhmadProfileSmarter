//using AhmadDAL.Models.Credentials;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace AhmadDAL.Models.AdminRequests
//{
//    [Table("AdminRequests")]
//    public class AdminRequests
//    {
//        [Key]
//        public int RequestId { get; set; }

//        [Required]
//        public int UserId { get; set; }

//        [Required]
//        [StringLength(100)]
//        public string RequestType { get; set; }

//        [Required]
//        [StringLength(200)]
//        public string Title { get; set; }

//        public string? Description { get; set; }

//        [StringLength(50)]
//        public string Status { get; set; } = "Pending";

//        public string? AdminRemarks { get; set; }

//        public DateTime CreatedAt { get; set; } = DateTime.Now;

//        public DateTime? UpdatedAt { get; set; }



//        // 🔗 Navigation Property
//        [ForeignKey(nameof(UserId))]
//        public User? User { get; set; }
//    }
//}
