using AutoMapper;
using LMSSystemAPI.Dbcontext;
using LMSSystemAPI.Dtos;
using LMSSystemAPI.Helpers;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace LMSSystemAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly LMSSystemContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly GenerateToken _generateToken;

        public AccountService(LMSSystemContext context, IConfiguration configuration, IMapper mapper, GenerateToken generateToken)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            _generateToken = generateToken;
        }
        public async Task<List<UserDto>> GetAllAccountAsync()
        {
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<List<UserDto>>(users);
        }
        public async Task<User> register(UserDto userDto)
        {
            var currentUser = _context.Users.FirstOrDefault(a => a.Email == userDto.Email);
            if (currentUser == null)
            {
                userDto.Password = Helpers.MD5.HashPasswordMD5(userDto.Password);
                userDto.RoleId = 2;
                userDto.ClassId = 1;
                userDto.FacultytId = 1;
                var user = _mapper.Map<User>(userDto);               
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }

        public async Task<string> Login(UserLoginDto userLoginDto)
        {
            var account = _context.Users.Where(a => a.Email == userLoginDto.Email).FirstOrDefault();
            if (account != null && Helpers.MD5.VerifyPasswordMD5(userLoginDto.Password, account.Password) == true)
            {           
                var token = _generateToken.Token(account);
                return token;
            }
            return string.Empty;
        }

    }
}
