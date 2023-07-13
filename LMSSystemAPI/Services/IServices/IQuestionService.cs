using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSSystemAPI.Services.IServices
{
    public interface IQuestionService
    {
        public Task<Question> CreateQuestion(QuesstionDto quesstionDto);
        public Task<ActionResult<IEnumerable<QuesstionDto>>> GetQuestions();
        public Task<ActionResult<QuesstionDto>> GetQuestionById(int id);
        public Task<QuesstionDto> UpdateQuestion(QuesstionDto quesstionDto, int id);
        public Task<bool> DeleteQuestion(int id);
      
    }
}
