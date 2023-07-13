using AutoMapper;
using LMSSystemAPI.Dbcontext;
using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSSystemAPI.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly LMSSystemContext _context;
        private readonly IMapper _mapper;
        public AnswerService(LMSSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Answer> CreateAnswer(AnswerDto answerDto)
        {
            var answerEntity = _mapper.Map<Answer>(answerDto);
            _context.Answers.Add(answerEntity);
            await _context.SaveChangesAsync();
            return answerEntity;
        }

        public async Task<ActionResult<IEnumerable<AnswerDto>>> GetAnswers()
        {
            var answers = await _context.Answers.Select(x => _mapper.Map<AnswerDto>(x)).ToListAsync();
            return answers;
        }

        public async Task<ActionResult<AnswerDto>> GetAnswerById(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            return _mapper.Map<AnswerDto>(answer);
        }

        public async Task<AnswerDto> UpdateAnswer(AnswerDto answerDto, int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null)
            {
                return null;
            }
            answer.AnswerName = answerDto.AnswerName;
            answer.QuestionId = answerDto.QuestionId;
            answer.Status = answerDto.Status;
            await _context.SaveChangesAsync();
            var answerEntity = _mapper.Map<AnswerDto>(answer);
            return answerEntity;
        }
        public async Task<bool> DeleteAnswer(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null)
            {
                return false;
            }
            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
