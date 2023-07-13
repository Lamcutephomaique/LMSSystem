using LMSSystemAPI.Dbcontext;
using LMSSystemAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LMSSystemAPI.Helpers
{
    public class GenerateToken
    {
        private readonly LMSSystemContext _context;
        private readonly IConfiguration _configuration;

        public GenerateToken(IConfiguration configuration, LMSSystemContext lMSContext)
        {
            _configuration = configuration;
            _context = lMSContext;
        }
        public string Token(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var RoleName = _context.Roles.Find(user.RoleId).RoleName;
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email.ToString()),
                new Claim(ClaimTypes.Role, RoleName.ToString())
            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        public string TokenTeacher(Teacher teacher)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var RoleName = _context.Roles.Find(teacher.RoleId).RoleName;
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, teacher.UserName.ToString()),
                new Claim(ClaimTypes.Role, RoleName.ToString())
            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
