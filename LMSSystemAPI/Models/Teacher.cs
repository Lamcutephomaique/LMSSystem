using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSSystemAPI.Models
{
    [Table("Teacher")]
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        public string TeacherName { get; set;}

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Image { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime UpdateDate { get; set; } = DateTime.Now;

        public int RoleId { get; set; }

        public Role Role { get; set; }

        public ICollection<Exam> Exams { get; set;}
        public ICollection<Course> Courses { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
 