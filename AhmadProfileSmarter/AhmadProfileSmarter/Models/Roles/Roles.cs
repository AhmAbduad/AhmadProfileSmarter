using AhmadDAL.Models.Credentials;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmadProfileSmarter.Models.Roles
{
    [Table("Roles")]
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [StringLength(100)]
        public string RoleName { get; set; } = null!;

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
