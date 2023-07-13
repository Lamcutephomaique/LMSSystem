using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSSystemAPI.Models
{
    [Table("UserCourse")]
    public class UserCourse
    {
        [Key]
        public int UserId { get; set; }
        public int CourseId { get; set; }

        public virtual User User { get; set; }

        public virtual Course Course { get; set; }
    }
}
