using LMSSystemAPI.Dtos;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCoursesController : ControllerBase
    {
        private readonly IUserCourseService _userCourseService;
        public UserCoursesController(IUserCourseService userCourseService)
        {
            _userCourseService = userCourseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCourseDto>>> GetAllUserCourses()
        {
            try
            {
                var userCourse = await _userCourseService.GetUserCourses();
                if (userCourse == null)
                {
                    return BadRequest("Null");
                }
                return Ok(userCourse);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserCourseDto>> CreateNotification(UserCourseDto userCourseDto)
        {
            var userCourse = await _userCourseService.CreateUserCourse(userCourseDto);
            if (userCourse == null)
            {
                return BadRequest("Null");
            }
            return Ok(userCourse);
        }
    }
}
