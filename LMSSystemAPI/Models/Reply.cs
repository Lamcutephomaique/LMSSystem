using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSSystemAPI.Models
{
    [Table("Reply")]
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }

        public string Body { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime UpdateDate { get; set; } = DateTime.Now;

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }
    }
}
