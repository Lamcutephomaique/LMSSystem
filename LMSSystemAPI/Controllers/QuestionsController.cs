using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuesstionDto>>> GetAllQuestions()
        {
            try
            {
                var question = await _questionService.GetQuestions();
                if (question == null)
                {
                    return BadRequest("Null");
                }
                return Ok(question);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<ActionResult<QuesstionDto>> CreateRole(QuesstionDto quesstionDto)
        {
            var quesstion = await _questionService.CreateQuestion(quesstionDto);
            if (quesstion == null)
            {
                return BadRequest("Null");
            }
            return Ok(quesstion);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Question>> GetQuesstionById(int id)
        {
            var question = await _questionService.GetQuestionById(id);
            if (question == null)
            {
                return BadRequest("Null");
            }
            return Ok(question);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateQuestion(QuesstionDto quesstionDto, int id)
        {
            try
            {
                var question = await _questionService.UpdateQuestion(quesstionDto, id);
                if (question == null)
                {
                    return NotFound("Null");
                }
                else
                {
                    return Ok(question);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _questionService.DeleteQuestion(id);
            if (question == false)
            {
                return NotFound("Null");
            }
            return Ok("Delete Success!");
        }

    }
}
