using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSSystemAPI.Models
{
    [Table("Class")]
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
       
        public string ClassName { get; set; } 

        public ICollection<User> Users { get; set;}
    }
}
