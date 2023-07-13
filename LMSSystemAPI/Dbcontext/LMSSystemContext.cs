using LMSSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LMSSystemAPI.Dbcontext
{
    public class LMSSystemContext : DbContext
    {
        public LMSSystemContext(DbContextOptions<LMSSystemContext> options) : base(options) { }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Faculty> Facultys { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Reply> Replys { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCourse> UserCourse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Answer    
            modelBuilder.Entity<Answer>()
               .HasOne(u => u.Question)
               .WithMany(r => r.Answers)
               .HasForeignKey(u => u.QuestionId)
               .OnDelete(DeleteBehavior.NoAction);

            //Class
            modelBuilder.Entity<Class>() 
                .HasMany(r => r.Users)
                .WithOne(u => u.Class)
                .HasForeignKey(u => u.ClassId)
                .OnDelete(DeleteBehavior.NoAction);

            //Comment
            modelBuilder.Entity<Comment>()
             .HasOne(u => u.Topic)
             .WithMany(r => r.Comments)
             .HasForeignKey(u => u.TopicId)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasMany(r => r.Replys)
                .WithOne(u => u.Comment)
                .HasForeignKey(u => u.ReplyId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
              .HasOne(u => u.User)
              .WithMany(r => r.Comments)
              .HasForeignKey(u => u.UserId)
              .OnDelete(DeleteBehavior.NoAction);

            //Course
            modelBuilder.Entity<Course>()
               .HasMany(r => r.Exams)
               .WithOne(u => u.Course)
               .HasForeignKey(u => u.CourseId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Course>()
              .HasOne(u => u.Teacher)
              .WithMany(r => r.Courses)
              .HasForeignKey(u => u.CourseId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Course>()
               .HasMany(r => r.Topics)
               .WithOne(u => u.Course)
               .HasForeignKey(u => u.CourseId)
               .OnDelete(DeleteBehavior.NoAction);

            //Exam
            modelBuilder.Entity<Exam>()
               .HasMany(r => r.Questions)
               .WithOne(u => u.Exam)
               .HasForeignKey(u => u.ExamId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Exam>()
               .HasOne(u => u.Teacher)
               .WithMany(r => r.Exams)
               .HasForeignKey(u => u.ExamId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Exam>()
               .HasOne(u => u.Course)
               .WithMany(r => r.Exams)
               .HasForeignKey(u => u.ExamId)
               .OnDelete(DeleteBehavior.NoAction);

            //Faculty
            modelBuilder.Entity<Faculty>()
               .HasMany(r => r.Users)
               .WithOne(u => u.Faculty)
               .HasForeignKey(u => u.UserId)
               .OnDelete(DeleteBehavior.NoAction);

            //Lesson
            modelBuilder.Entity<Lesson>()
              .HasOne(u => u.Topic)
              .WithMany(r => r.Lessons)
              .HasForeignKey(u => u.TopicId)
              .OnDelete(DeleteBehavior.NoAction);

            //Notification
            modelBuilder.Entity<Notification>()
                .HasKey(c => new { c.UserId, c.TeacherId });

            modelBuilder.Entity<Notification>()
                 .HasOne(p => p.User)
                 .WithMany(a => a.Notifications)
                 .HasForeignKey(p => p.UserId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(r => r.Notifications)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notification>()
                .HasOne(p => p.Teacher)
                .WithMany(a => a.Notifications)
                .HasForeignKey(p => p.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Teacher>()
                .HasMany(r => r.Notifications)
                .WithOne(a => a.Teacher)
                .HasForeignKey(a => a.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            //Question
            modelBuilder.Entity<Question>()
                .HasMany(r => r.Answers)
                .WithOne(u => u.Question)
                .HasForeignKey(u => u.QuestionId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Question>()
                .HasOne(u => u.Exam)
                .WithMany(r => r.Questions)
                .HasForeignKey(u => u.ExamId)
                .OnDelete(DeleteBehavior.NoAction);

            //Reply
            modelBuilder.Entity<Reply>()
             .HasOne(u => u.Comment)
             .WithMany(r => r.Replys)
             .HasForeignKey(u => u.CommentId)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Reply>()
              .HasOne(u => u.User)
              .WithMany(r => r.Replys)
              .HasForeignKey(u => u.UserId)
              .OnDelete(DeleteBehavior.NoAction);

            //Role
            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Role>()
               .HasMany(r => r.Teachers)
               .WithOne(u => u.Role)
               .HasForeignKey(u => u.RoleId)
               .OnDelete(DeleteBehavior.NoAction);

            //Teacher
            modelBuilder.Entity<Teacher>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Teachers)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Teacher>()
               .HasMany(r => r.Exams)
               .WithOne(u => u.Teacher)
               .HasForeignKey(u => u.TeacherId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Teacher>()
              .HasMany(r => r.Courses)
              .WithOne(u => u.Teacher)
              .HasForeignKey(u => u.TeacherId)
              .OnDelete(DeleteBehavior.NoAction);

            //Topic
            modelBuilder.Entity<Topic>()
               .HasOne(u => u.Course)
               .WithMany(r => r.Topics)
               .HasForeignKey(u => u.CourseId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Topic>()
                .HasMany(r => r.Lessons)
                .WithOne(u => u.Topic)
                .HasForeignKey(u => u.TopicId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Topic>()
                .HasMany(r => r.Comments)
                .WithOne(u => u.Topic)
                .HasForeignKey(u => u.TopicId)
                .OnDelete(DeleteBehavior.NoAction);

            //Use
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Class)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.ClassId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
               .HasMany(r => r.Replys)
               .WithOne(u => u.User)
               .HasForeignKey(u => u.ReplyId)
               .OnDelete(DeleteBehavior.NoAction);

             modelBuilder.Entity<User>()
                .HasMany(r => r.Comments)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.CommentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
             .HasOne(u => u.Faculty)
             .WithMany(r => r.Users)
             .HasForeignKey(u => u.FacultytId)
             .OnDelete(DeleteBehavior.NoAction);

            //UserCourse
            modelBuilder.Entity<UserCourse>()
                .HasKey(c => new { c.UserId, c.CourseId });

            modelBuilder.Entity<UserCourse>()
                 .HasOne(p => p.User)
                 .WithMany(a => a.UserCourses)
                 .HasForeignKey(p => p.UserId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(r => r.UserCourses)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserCourse>()
                .HasOne(p => p.Course)
                .WithMany(a => a.UserCourses)
                .HasForeignKey(p => p.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
                .HasMany(r => r.UserCourses)
                .WithOne(a => a.Course)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
