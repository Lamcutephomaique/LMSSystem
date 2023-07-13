using AutoMapper;
using LMSSystemAPI.Dbcontext;
using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;       
        }
      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetAllRole()
        {
            try 
            {           
                var role = await _roleService.GetRoles();
                if (role == null)
                {
                    return BadRequest("Null");
                }
                return Ok(role);
            } 
            catch 
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<ActionResult<RoleDto>> CreateRole(RoleDto roleDto)
        {
            var role = await _roleService.CreateRole(roleDto);
            if (role == null)
            {
                return BadRequest("Null");
            }
            return Ok(role);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Role>> GetRoleById(int id)
        {
            var role = await _roleService.GetRoleById(id);
            if (role == null)
            {
                return BadRequest("Null");
            }
            return Ok(role);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateRole(RoleDto roleDto, int id)
        {
           
            
            try
            {
               var role= await _roleService.UpdateRole(roleDto, id);
                if (role == null)
                {
                    return NotFound("Null");
                }
                else 
                {   
                    return Ok(role);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }         
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _roleService.DeleteRole(id);
            if (role == false)
            {
                return NotFound("Null");
            }        
            return Ok("Delete Success!");
        }

    }
}
