using AutoMapper;
using LMSSystemAPI.Dbcontext;
using LMSSystemAPI.Dtos;
using LMSSystemAPI.Helpers;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace LMSSystemAPI.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly LMSSystemContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly GenerateToken _generateToken;

        public TeacherService(LMSSystemContext context, IConfiguration configuration, IMapper mapper, GenerateToken generateToken)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            _generateToken = generateToken;
        }
        public async Task<List<TeacherDto>> GetAllAccountTeacherAsync()
        {
            var teachers = await _context.Teachers.ToListAsync();
            return _mapper.Map<List<TeacherDto>>(teachers);
        }
        public async Task<Teacher> register(TeacherDto teacherDto)
        {
            var currentTeacher = _context.Teachers.FirstOrDefault(a => a.UserName == teacherDto.UserName);
            if (currentTeacher == null)
            {
                teacherDto.Password = Helpers.MD5.HashPasswordMD5(teacherDto.Password);
                teacherDto.RoleId = 2;
                var teacher = _mapper.Map<Teacher>(teacherDto);
                _context.Teachers.Add(teacher);
                await _context.SaveChangesAsync();
                return teacher;
            }
            return null;
        }

        public async Task<string> Login(TeacherLoginDto teacherLoginDto)
        {
            var account = _context.Teachers.Where(a => a.UserName == teacherLoginDto.UserName).FirstOrDefault();
            if (account != null && Helpers.MD5.VerifyPasswordMD5(teacherLoginDto.Password, account.Password) == true)
            {
                var token = _generateToken.TokenTeacher(account);
                return token;
            }
            return string.Empty;
        }
    }
}
