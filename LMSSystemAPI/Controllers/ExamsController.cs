using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamService _examService;
        public ExamsController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamDto>>> GetAllExam()
        {
            try
            {
                var exam = await _examService.GetExams();
                if (exam == null)
                {
                    return BadRequest("Null");
                }
                return Ok(exam);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<ActionResult<ExamDto>> CreateExam(ExamDto examDto)
        {
            var exam = await _examService.CreateExam(examDto);
            if (exam == null)
            {
                return BadRequest("Null");
            }
            return Ok(exam);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Exam>> GetExamById(int id)
        {
            var exam = await _examService.GetExamById(id);
            if (exam == null)
            {
                return BadRequest("Null");
            }
            return Ok(exam);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateExam(ExamDto examDto, int id)
        {
            try
            {
                var exam = await _examService.UpdateExam(examDto, id);
                if (exam == null)
                {
                    return NotFound("Null");
                }
                else
                {
                    return Ok(exam);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var exam = await _examService.DeleteExam(id);
            if (exam == false)
            {
                return NotFound("Null");
            }
            return Ok("Delete Success!");
        }
    }
}
