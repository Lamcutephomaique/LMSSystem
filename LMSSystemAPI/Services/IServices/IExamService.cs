using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMSSystemAPI.Services.IServices
{
    public interface IExamService
    {

        public Task<Exam> CreateExam(ExamDto examDto);
        public Task<ActionResult<IEnumerable<ExamDto>>> GetExams();

        public Task<ActionResult<ExamDto>> GetExamById(int id);

        public Task<ExamDto> UpdateExam(ExamDto examDto, int id);

        public Task<bool> DeleteExam(int id);

    }
}
