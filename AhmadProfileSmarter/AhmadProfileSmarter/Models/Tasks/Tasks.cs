using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AhmadDAL.Models.Status;
using AhmadDAL.Models.Account;
using AhmadDAL.Models.Meetings;
using AhmadDAL.Models.Attachment;
using AhmadDAL.Models.Activity;
using AhmadDAL.Models.Comments;
using AhmadDAL.Models.Credentials;

namespace AhmadDAL.Models.Tasks
{
    [Table("Tasks")]
    public class Tasks
    {
        [Key]
        public int TaskID { get; set; }

        [StringLength(300)]
        public string? TaskName { get; set; }

        [StringLength(100)]
        public string? LateDays { get; set; }

        [StringLength(200)]
        public string? Salary { get; set; }

        public DateTime? LastActivity { get; set; }

        // 🔑 Foreign Keys
        [Required]
        public int? StatusID { get; set; }

        [Required]
        public int? AccountID { get; set; }

        //[Required]
        //public int? AttachmentID { get; set; }

        //[Required]
        //public int? MeetingsID { get; set; }

        //[Required]
        //public int? ActivityID { get; set; }

        //[Required]
        //public int? CommentsID { get; set; }


        //[Required]
        //public int FilesID { get; set; }



        public Status.Status? Status { get; set; }
        public Account.Account? Account { get; set; }


        // 🔗 Navigation Properties


        //[ForeignKey(nameof(StatusID))]
        //public Status.Status? Status { get; set; }

        //[ForeignKey(nameof(AccountID))]
        //public Account.Account? Account { get; set; }

        //[ForeignKey(nameof(AttachmentID))]
        //public Attachment.Attachment? Attachment { get; set; }

        //[ForeignKey(nameof(MeetingsID))]
        //public  Meetings.Meetings? Meetings { get; set; }


        //[ForeignKey(nameof(ActivityID))]
        //public Activity.Activity? Activity { get; set; }

        //[ForeignKey(nameof(CommentsID))]
        //public Comments.Comments? Comments { get; set; }


        public ICollection<Attachment.Attachment> Attachments { get; set; } = new List<Attachment.Attachment>();
        public ICollection<Meetings.Meetings> Meetings { get; set; } = new List<Meetings.Meetings>();
        public ICollection<Activity.Activity> Activity { get; set; } = new List<Activity.Activity>();
        public ICollection<Comments.Comments> Comments { get; set; } = new List<Comments.Comments>();



        //[ForeignKey(nameof(FilesID))]
        //public Files.Files? Files { get; set; }
    }
}
