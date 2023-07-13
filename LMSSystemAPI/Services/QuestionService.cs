using AutoMapper;
using LMSSystemAPI.Dbcontext;
using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSSystemAPI.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly LMSSystemContext _context;
        private readonly IMapper _mapper;
        public QuestionService(LMSSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Question> CreateQuestion(QuesstionDto quesstionDto)
        {
            var quesstionEntity = _mapper.Map<Question>(quesstionDto);
            _context.Questions.Add(quesstionEntity);
            await _context.SaveChangesAsync();
            return quesstionEntity;
        }

        public async Task<ActionResult<IEnumerable<QuesstionDto>>> GetQuestions()
        {
            var quesstions = await _context.Questions.Select(x => _mapper.Map<QuesstionDto>(x)).ToListAsync();
            return quesstions;
        }

        public async Task<ActionResult<QuesstionDto>> GetQuestionById(int id)
        {
            var quesstion = await _context.Questions.FindAsync(id);
            return _mapper.Map<QuesstionDto>(quesstion);
        }

        public async Task<QuesstionDto> UpdateQuestion(QuesstionDto quesstionDto, int id)
        {
            var quesstion = await _context.Questions.FindAsync(id);
            if (quesstion == null)
            {
                return null;
            }
            quesstion.Title = quesstionDto.Title;
            await _context.SaveChangesAsync();
            var quesstionEntity = _mapper.Map<QuesstionDto>(quesstion);
            return quesstionEntity;
        }
        public async Task<bool> DeleteQuestion(int id)
        {
            var quesstion = await _context.Questions.FindAsync(id);
            if (quesstion == null)
            {
                return false;
            }
            _context.Questions.Remove(quesstion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
