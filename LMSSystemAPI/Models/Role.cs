using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSSystemAPI.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set;}

        public ICollection<Teacher> Teachers { get; set; }
    }
}
