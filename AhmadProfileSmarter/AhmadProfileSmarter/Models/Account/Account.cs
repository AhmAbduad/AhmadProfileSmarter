using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmadDAL.Models.Account
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int AccountID { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string AccountName { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }
    }
}


