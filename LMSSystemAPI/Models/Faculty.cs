using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMSSystemAPI.Models
{
    [Table("Faculty")]
    public class Faculty
    {
        [Key]
        public int FacultytId { get; set; }

        public string FacultytName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
