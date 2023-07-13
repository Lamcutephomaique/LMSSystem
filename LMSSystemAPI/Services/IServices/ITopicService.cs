using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSSystemAPI.Services.IServices
{
    public interface ITopicService
    {
        public Task<Topic> CreateTopic(TopicDto topicDto);

        public Task<ActionResult<IEnumerable<TopicDto>>> GetTopics();
        
        public Task<ActionResult<TopicDto>> GetTopicById(int id);

        public Task<TopicDto> UpdateTopic(TopicDto topicDto, int id);

        public Task<bool> DeleteTopic(int id);
      
    }
}
