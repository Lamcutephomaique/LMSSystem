using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicService _topicService;
        public TopicsController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicDto>>> GetAllTopic()
        {
            try
            {
                var topic = await _topicService.GetTopics();
                if (topic == null)
                {
                    return BadRequest("Null");
                }
                return Ok(topic);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<ActionResult<TopicDto>> CreateTopic(TopicDto topicDto)
        {
            var topic = await _topicService.CreateTopic(topicDto);
            if (topic == null)
            {
                return BadRequest("Null");
            }
            return Ok(topic);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Topic>> GetTopicById(int id)
        {
            var topic = await _topicService.GetTopicById(id);
            if (topic == null)
            {
                return BadRequest("Null");
            }
            return Ok(topic);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateTopic(TopicDto topicDto, int id)
        {


            try
            {
                var topic = await _topicService.UpdateTopic(topicDto, id);
                if (topic == null)
                {
                    return NotFound("Null");
                }
                else
                {
                    return Ok(topic);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var topic = await _topicService.DeleteTopic(id);
            if (topic == false)
            {
                return NotFound("Null");
            }
            return Ok("Delete Success!");
        }

    }
}
