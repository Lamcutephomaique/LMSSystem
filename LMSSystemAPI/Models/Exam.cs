using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSSystemAPI.Models
{
    [Table("Exam")]
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }

        public string ExamName { get; set; }

        public int Time { get; set; }

        public int Status { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public int TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
