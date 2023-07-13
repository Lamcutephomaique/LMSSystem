using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSSystemAPI.Models
{
    [Table("Answer")]
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public string AnswerName { get; set; }
        public int QuestionId { get; set; }
        public int Status { get; set; }

        public virtual Question Question { get; set; }
    }
}
