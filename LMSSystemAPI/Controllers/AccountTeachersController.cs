using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTeachersController : ControllerBase
    {

        private readonly ITeacherService _teacherService;
        public AccountTeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherDto>>> GetAllTeacher()
        {
            try
            {
                var Teachers = await _teacherService.GetAllAccountTeacherAsync();
                if (Teachers == null)
                {
                    return BadRequest("Null");
                }
                return Ok(Teachers);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("Register")]
        public async Task<ActionResult<Teacher>> Register(TeacherDto teacherDto)
        {
            var Teacher = await _teacherService.register(teacherDto);
            if (Teacher == null)
            {
                return BadRequest("Tài khoản đã tồn tại");
            }
            return BadRequest("Đăng ký tài khoản thành công");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(TeacherLoginDto teacherLoginDto)
        {
            var result = await _teacherService.Login(teacherLoginDto);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
