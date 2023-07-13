using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSSystemAPI.Models
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [StringLength(100)]
        public string Body { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime UpdateDate { get; set; } = DateTime.Now;

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int TopicId { get; set; }

        public virtual Topic Topic { get; set; }

        public ICollection<Reply> Replys { get; set; }
    }
}
