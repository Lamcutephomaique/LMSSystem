using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LMSSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUser()
        {
            try
            {
                var users = await _accountService.GetAllAccountAsync();
                if (users == null)
                {
                    return BadRequest("Null");
                }
                return Ok(users);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserDto userDto)
        {
            var user = await _accountService.register(userDto);
            if (user == null)
            {   
                return BadRequest("Tài khoản đã tồn tại");
            }
            return BadRequest("Đăng ký tài khoản thành công");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var result = await _accountService.Login(userLoginDto);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }

    }
}
