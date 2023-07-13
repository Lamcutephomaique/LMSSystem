using AutoMapper;
using LMSSystemAPI.Dbcontext;
using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSSystemAPI.Services
{
    public class CourseService : ICourseService
    {
        private readonly LMSSystemContext _context;
        private readonly IMapper _mapper;
        public CourseService(LMSSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Course> CreateCourse(CourseDto courseDto)
        {
            courseDto.TeacherId = 1;
            var ourseEntity = _mapper.Map<Course>(courseDto);
            _context.Courses.Add(ourseEntity);
            await _context.SaveChangesAsync();
            return ourseEntity;
        }

        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses()
        {
            var Courses = await _context.Courses.Select(x => _mapper.Map<CourseDto>(x)).ToListAsync();
            return Courses;
        }

        public async Task<ActionResult<CourseDto>> GetCourseById(int id)
        {
            var Course = await _context.Courses.FindAsync(id);
            return _mapper.Map<CourseDto>(Course);
        }

        public async Task<CourseDto> UpdateCourse(CourseDto courseDto, int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return null;
            }
            course.CourseName = courseDto.CourseName;
            await _context.SaveChangesAsync();
            var courseEntity = _mapper.Map<CourseDto>(course);
            return courseEntity;
        }
        public async Task<bool> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return false;
            }
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
