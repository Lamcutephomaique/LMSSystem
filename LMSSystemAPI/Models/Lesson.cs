using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSSystemAPI.Models
{
    [Table("Lesson")]
    public class Lesson
    {
        [Key]
        public int LessonID { get; set; }

        public string LessonName { get; set; }

        public int Time { get; set; }

        public string FileName { get; set; }

        public int TopicId { get; set; }

        public virtual Topic Topic { get; set; }

    }
}
