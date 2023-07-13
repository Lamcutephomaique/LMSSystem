using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSSystemAPI.Models
{
    [Table("Question")]
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        public string Title { get; set; }

        public int ExamId { get; set; }

        public virtual Exam Exam { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
