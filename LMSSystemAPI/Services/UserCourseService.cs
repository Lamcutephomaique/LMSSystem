using AutoMapper;
using LMSSystemAPI.Dbcontext;
using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSSystemAPI.Services
{
    public class UserCourseService : IUserCourseService
    {
        private readonly LMSSystemContext _context;
        private readonly IMapper _mapper;
        public UserCourseService(LMSSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserCourse> CreateUserCourse(UserCourseDto userCourseDto)
        {
            var userCourseEntity = _mapper.Map<UserCourse>(userCourseDto);
            _context.UserCourse.Add(userCourseEntity);
            await _context.SaveChangesAsync();
            return userCourseEntity;
        }

        public async Task<ActionResult<IEnumerable<UserCourseDto>>> GetUserCourses()
        {
            var userCourse = await _context.UserCourse.Select(x => _mapper.Map<UserCourseDto>(x)).ToListAsync();
            return userCourse;
        }
    }
}
