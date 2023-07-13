using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAllCourse()
        {
            try
            {
                var course = await _courseService.GetCourses();
                if (course == null)
                {
                    return BadRequest("Null");
                }
                return Ok(course);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<ActionResult<CourseDto>> CreateCourse(CourseDto rourseDto)
        {
            var course = await _courseService.CreateCourse(rourseDto);
            if (course == null)
            {
                return BadRequest("Null");
            }
            return Ok(course);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Course>> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseById(id);
            if (course == null)
            {
                return BadRequest("Null");
            }
            return Ok(course);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateCourse(CourseDto courseDto, int id)
        {


            try
            {
                var course = await _courseService.UpdateCourse(courseDto, id);
                if (course == null)
                {
                    return NotFound("Null");
                }
                else
                {
                    return Ok(course);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _courseService.DeleteCourse(id);
            if (course == false)
            {
                return NotFound("Null");
            }
            return Ok("Delete Success!");
        }
    }
}
