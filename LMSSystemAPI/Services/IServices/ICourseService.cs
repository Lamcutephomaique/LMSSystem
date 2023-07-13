using AutoMapper;
using LMSSystemAPI.Dbcontext;
using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSSystemAPI.Services.IServices
{
    public interface ICourseService
    {
        public Task<Course> CreateCourse(CourseDto courseDto);
        public Task<ActionResult<IEnumerable<CourseDto>>> GetCourses();
        public Task<ActionResult<CourseDto>> GetCourseById(int id);
        public Task<CourseDto> UpdateCourse(CourseDto courseDto, int id);
        public Task<bool> DeleteCourse(int id);   
    }
}
