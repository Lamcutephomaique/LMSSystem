using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        public AnswersController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnswerDto>>> GetAllAnswers()
        {
            try
            {
                var answer = await _answerService.GetAnswers();
                if (answer == null)
                {
                    return BadRequest("Null");
                }
                return Ok(answer);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<ActionResult<RoleDto>> CreateAnswer(AnswerDto answerDto)
        {
            var answer = await _answerService.CreateAnswer(answerDto);
            if (answer == null)
            {
                return BadRequest("Null");
            }
            return Ok(answer);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Answer>> GetAnswerById(int id)
        {
            var answer = await _answerService.GetAnswerById(id);
            if (answer == null)
            {
                return BadRequest("Null");
            }
            return Ok(answer);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateRoleAnswer(AnswerDto answerDto, int id)
        {
            try
            {
                var answer = await _answerService.UpdateAnswer(answerDto, id);
                if (answer == null)
                {
                    return NotFound("Null");
                }
                else
                {
                    return Ok(answer);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            var answer = await _answerService.DeleteAnswer(id);
            if (answer == false)
            {
                return NotFound("Null");
            }
            return Ok("Delete Success!");
        }
    }
}
