namespace LMSSystemAPI.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Image { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime UpdateDate { get; set; } = DateTime.Now;

        public int RoleId { get; set; }

        public int ClassId { get; set; }

        public int FacultytId { get; set; }


    }
}
