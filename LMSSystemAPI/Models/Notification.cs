using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSSystemAPI.Models
{
    [Table("Notification")]
    public class Notification
    {
        [Key]
        public int UserId { get; set; }
        public int TeacherId { get; set; }

        public virtual User User { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
