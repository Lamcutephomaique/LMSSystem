using AutoMapper;
using LMSSystemAPI.Dbcontext;
using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSSystemAPI.Services
{
    public class TopicService : ITopicService
    {
        private readonly LMSSystemContext _context;
        private readonly IMapper _mapper;
        public TopicService(LMSSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Topic> CreateTopic(TopicDto topicDto)
        {
            var topicEntity = _mapper.Map<Topic>(topicDto);
            _context.Topics.Add(topicEntity);
            await _context.SaveChangesAsync();
            return topicEntity;
        }

        public async Task<ActionResult<IEnumerable<TopicDto>>> GetTopics()
        {
            var topics = await _context.Topics.Select(x => _mapper.Map<TopicDto>(x)).ToListAsync();
            return topics;
        }

        public async Task<ActionResult<TopicDto>> GetTopicById(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            return _mapper.Map<TopicDto>(topic);
        }

        public async Task<TopicDto> UpdateTopic(TopicDto topicDto, int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return null;
            }
            topic.TopicName = topicDto.TopicName;
            await _context.SaveChangesAsync();
            var topicEntity = _mapper.Map<TopicDto>(topic);
            return topicEntity;
        }
        public async Task<bool> DeleteTopic(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return false;
            }
            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
