using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSSystemAPI.Models
{
    [Table("Course")]
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        public string CourseName { get; set;}

        public int TeacherId { get; set;}

        public Teacher Teacher { get; set;}

        public ICollection<Topic> Topics { get; set; }

        public ICollection<UserCourse> UserCourses { get; set; }

        public ICollection<Exam> Exams { get; set; }
    }
}
