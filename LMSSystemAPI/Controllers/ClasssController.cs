using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasssController : ControllerBase
    {
        private readonly IClassService _classService;
        public ClasssController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassDto>>> GetAllClass()
        {
            try
            {
                var classs = await _classService.GetClasses();
                if (classs == null)
                {
                    return BadRequest("Null");
                }
                return Ok(classs);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<ActionResult<ClassDto>> CreateClass(ClassDto classDto)
        {
            var classs= await _classService.CreateClass(classDto);
            if (classs == null)
            {
                return BadRequest("Null");
            }
            return Ok(classs);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Class>> GetClassById(int id)
        {
            var classs = await _classService.GetClassById(id);
            if (classs == null)
            {
                return BadRequest("Null");
            }
            return Ok(classs);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateClass(ClassDto classDto, int id)
        {


            try
            {
                var Class = await _classService.UpdateClass(classDto, id);
                if (Class == null)
                {
                    return NotFound("Null");
                }
                else
                {
                    return Ok(Class);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var Class = await _classService.DeleteClass(id);
            if (Class == false)
            {
                return NotFound("Null");
            }
            return Ok("Delete Success!");
        }

    }
}
