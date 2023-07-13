using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSSystemAPI.Services.IServices
{
    public interface IAnswerService
    {
        public Task<Answer> CreateAnswer(AnswerDto answerDto);

        public Task<ActionResult<IEnumerable<AnswerDto>>> GetAnswers();

        public Task<ActionResult<AnswerDto>> GetAnswerById(int id);

        public Task<AnswerDto> UpdateAnswer(AnswerDto answerDto, int id);

        public Task<bool> DeleteAnswer(int id);
       
    }
}
