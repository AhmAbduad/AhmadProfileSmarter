using AhmadDAL.Models.Credentials;
using AhmadDAL.Models.Employees;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AhmadDAL.Models.Participants
{
    [Table("Participant")]
    public class Participant
    {
        [Key]
        public int ParticipantID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        [MaxLength(100)]
        public string ParticipantName { get; set; } = null!;

        public bool IsActive { get; set; }

        [ForeignKey(nameof(EmployeeID))]
        public Employees.Employee? Employee { get; set; }
    }
}
