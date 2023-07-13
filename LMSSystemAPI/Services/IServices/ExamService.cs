using AutoMapper;
using LMSSystemAPI.Dbcontext;
using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSSystemAPI.Services.IServices
{
    public class ExamService : IExamService
    {
        private readonly LMSSystemContext _context;
        private readonly IMapper _mapper;
        public ExamService(LMSSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Exam> CreateExam(ExamDto examDto)
        {
            var examEntity = _mapper.Map<Exam>(examDto);
            _context.Exams.Add(examEntity);
            await _context.SaveChangesAsync();
            return examEntity;
        }

        public async Task<ActionResult<IEnumerable<ExamDto>>> GetExams()
        {
            var Exams = await _context.Exams.Select(x => _mapper.Map<ExamDto>(x)).ToListAsync();
            return Exams;
        }

        public async Task<ActionResult<ExamDto>> GetExamById(int id)
        {
            var Exam = await _context.Exams.FindAsync(id);
            return _mapper.Map<ExamDto>(Exam);
        }

        public async Task<ExamDto> UpdateExam(ExamDto examDto, int id)
        {
            var Exam = await _context.Exams.FindAsync(id);
            if (Exam == null)
            {
                return null;
            }
            Exam.ExamName = examDto.ExamName;
            Exam.Time = examDto.Time;
            Exam.Status = examDto.Status;
            await _context.SaveChangesAsync();
            var ExamEntity = _mapper.Map<ExamDto>(Exam);
            return ExamEntity;
        }
        public async Task<bool> DeleteExam(int id)
        {
            var Exam = await _context.Exams.FindAsync(id);
            if (Exam == null)
            {
                return false;
            }
            _context.Exams.Remove(Exam);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
