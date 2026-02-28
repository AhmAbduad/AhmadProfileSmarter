using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmadDAL.Models.Status
{

    [Table("Status")]
    public class Status
    {
        [Key]
        public int StatusID { get; set; }

        [Required]
        [StringLength(100)]
        public string StatusName { get; set; }
    }
}
