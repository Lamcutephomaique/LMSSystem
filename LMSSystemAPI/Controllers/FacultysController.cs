using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultysController : ControllerBase
    {
        private readonly IFacultyService _facultyService;
        public FacultysController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacultyDto>>> GetAllFaculty()
        {
            try
            {
                var faculty = await _facultyService.GetFacultys();
                if (faculty == null)
                {
                    return BadRequest("Null");
                }
                return Ok(faculty);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<ActionResult<FacultyDto>> CreateFacultye(FacultyDto facultyDto)
        {
            var faculty = await _facultyService.CreateFaculty(facultyDto);
            if (faculty == null)
            {
                return BadRequest("Null");
            }
            return Ok(faculty);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Faculty>> GetFacultyById(int id)
        {
            var faculty = await _facultyService.GetFacultyById(id);
            if (faculty == null)
            {
                return BadRequest("Null");
            }
            return Ok(faculty);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateFaculty(FacultyDto facultyDto, int id)
        {


            try
            {
                var faculty = await _facultyService.UpdateFaculty(facultyDto, id);
                if (faculty == null)
                {
                    return NotFound("Null");
                }
                else
                {
                    return Ok(faculty);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaculty(int id)
        {
            var faculty = await _facultyService.DeleteFaculty(id);
            if (faculty == false)
            {
                return NotFound("Null");
            }
            return Ok("Delete Success!");
        }

    }
}

