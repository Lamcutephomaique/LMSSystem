using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonService _lessonService;
        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonDto>>> GetAllLesson()
        {
            try
            {
                var lesson = await _lessonService.GetLessons();
                if (lesson == null)
                {
                    return BadRequest("Null");
                }
                return Ok(lesson);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<ActionResult<LessonDto>> CreateLesson(LessonDto lessonDto)
        {
            var lesson = await _lessonService.CreateLesson(lessonDto);
            if (lesson == null)
            {
                return BadRequest("Null");
            }
            return Ok(lesson);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Lesson>> GetLessonById(int id)
        {
            var lesson = await _lessonService.GetLessonById(id);
            if (lesson == null)
            {
                return BadRequest("Null");
            }
            return Ok(lesson);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateLesson(LessonDto lessonDto, int id)
        {


            try
            {
                var lesson = await _lessonService.UpdateLesson(lessonDto, id);
                if (lesson == null)
                {
                    return NotFound("Null");
                }
                else
                {
                    return Ok(lesson);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var lesson = await _lessonService.DeleteLesson(id);
            if (lesson == false)
            {
                return NotFound("Null");
            }
            return Ok("Delete Success!");
        }

    }
}
