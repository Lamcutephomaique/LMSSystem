using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMSSystemAPI.Models
{
    [Table("Topic")]
    public class Topic
    {
        [Key]
        public int TopicId { get; set; }

        public string TopicName { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
