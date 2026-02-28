using AhmadDAL.Models.Credentials;
using AhmadDAL.Models.Participants;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmadDAL.Models.Employees
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        public int UserId { get; set; }

        [MaxLength(100)]
        public string? Designation { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }

        public DateTime JoinDate { get; set; }

        //// 🔗 Navigation Property
        //public virtual User User { get; set; } = null!;

        // 🔗 Navigation Property
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }


        // 🔗 Participants
        public ICollection<Participant> Participants { get; set; } = new List<Participant>();
    }
}
