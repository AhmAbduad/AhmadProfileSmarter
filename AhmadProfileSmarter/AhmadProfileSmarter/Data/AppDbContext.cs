using AhmadDAL.Models.Account;
using AhmadDAL.Models.Activity;
using AhmadDAL.Models.AdminRequests;
using AhmadDAL.Models.AIChatMessage;
using AhmadDAL.Models.Attachment;
using AhmadDAL.Models.Chats;
using AhmadDAL.Models.Comments;
using AhmadDAL.Models.Credentials;
using AhmadDAL.Models.EmployeeFiles;
using AhmadDAL.Models.Employees;
using AhmadDAL.Models.Meetings;
using AhmadDAL.Models.Notifications;
using AhmadDAL.Models.ParticipantFiles;
using AhmadDAL.Models.Participants;
using AhmadDAL.Models.PersonalFiles;
using AhmadDAL.Models.Reportbug;
using AhmadDAL.Models.Status;
using AhmadDAL.Models.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AhmadDAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // ================== AUTH ==================
        public DbSet<User> Users { get; set; }

        // ================== CORE ==================
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public DbSet<Employee> Employee { get; set; } 

        public DbSet<Participant> Participants { get; set; }

        // ================== TASK CHILD TABLES ==================
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Meetings> Meetings { get; set; }

        // ================== OTHERS ==================
        public DbSet<Reportbug> Reportbugs { get; set; }

        public DbSet<ParticipantFiles> ParticipantFiles { get; set; }

        public DbSet<PersonalFiles> PersonalFiles { get; set; }

        public DbSet<EmployeeFiles> EmployeeFiles { get; set; }

        public DbSet<Notifications> Notifications { get; set; }

        public DbSet<Chats> Chats { get; set; }

        public DbSet<MeetingParticipants> MeetingParticipants { get; set; }

        public DbSet<AIChatMessage> AIChatMessages { get; set; }

        public DbSet<AdminRequests> AdminRequests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ================== TASK RELATIONSHIPS ==================

            modelBuilder.Entity<Attachment>()
                .HasOne(a => a.Task)
                .WithMany(t => t.Attachments)
                .HasForeignKey(a => a.TaskID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Activity>()
                .HasOne(a => a.Task)
                .WithMany(t => t.Activity)
                .HasForeignKey(a => a.TaskID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comments>()
                .HasOne(c => c.Task)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TaskID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Meetings>()
                .HasOne(m => m.Task)
                .WithMany(t => t.Meetings)
                .HasForeignKey(m => m.TaskID)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Meetings>()
                .HasOne(m=>m.User)
                .WithMany(t => t.Meetings)
                .HasForeignKey(m=>m.CreatedBy)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Employee>()
                .HasOne(e => e.User)           // Employee ka navigation property User
                .WithMany(u => u.Employees)    // User ka navigation property Employees (collection)
                .HasForeignKey(e => e.UserId)  // Employee table ka foreign key
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Participant>()
                .HasOne(p => p.Employee)
                .WithMany(e => e.Participants)
                .HasForeignKey(p => p.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Chats>()
                .HasOne(c => c.Sender)
                .WithMany(u => u.SentChats)
                .HasForeignKey(c => c.SenderID)
                .OnDelete(DeleteBehavior.NoAction); // <-- no cascade


            modelBuilder.Entity<Chats>()
                .HasOne(c => c.Receiver)
                .WithMany(u => u.ReceivedChats)
                .HasForeignKey(c => c.ReceiverID)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Notifications>()
                .HasOne(n => n.Sender)
                .WithMany(u => u.SentNotifications)
                .HasForeignKey(n => n.SenderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Notifications>()
                .HasOne(n => n.Receiver)
                .WithMany(u => u.ReceivedNotifications)
                .HasForeignKey(n => n.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<MeetingParticipants>()
                .HasOne(mp => mp.Meeting)       // Each participant belongs to one meeting
                .WithMany(m => m.MeetingPart)  // Each meeting has many participants
                .HasForeignKey(mp => mp.MeetingID)
                .OnDelete(DeleteBehavior.Cascade);

            // User -> MeetingParticipants (one-to-many)
            modelBuilder.Entity<MeetingParticipants>()
                .HasOne(mp => mp.User)          // Each participant belongs to one user
                .WithMany(u => u.MeetingPart) // Each user can participate in many meetings
                .HasForeignKey(mp => mp.UserID)
                .OnDelete(DeleteBehavior.NoAction);
                
            modelBuilder.Entity<AdminRequests>()
                .HasOne(mp=>mp.User)
                .WithMany(u=>u.AdminRequests)
                .HasForeignKey(mp=>mp.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
