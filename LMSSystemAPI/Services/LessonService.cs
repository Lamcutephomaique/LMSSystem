using AutoMapper;
using LMSSystemAPI.Dbcontext;
using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSSystemAPI.Services
{
    public class LessonService : ILessonService
    {
        private readonly LMSSystemContext _context;
        private readonly IMapper _mapper;
        public LessonService(LMSSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Lesson> CreateLesson(LessonDto lessonDto)
        {
            var lessonEntity = _mapper.Map<Lesson>(lessonDto);
            _context.Lessons.Add(lessonEntity);
            await _context.SaveChangesAsync();
            return lessonEntity;
        }

        public async Task<ActionResult<IEnumerable<LessonDto>>> GetLessons()
        {
            var lessons = await _context.Lessons.Select(x => _mapper.Map<LessonDto>(x)).ToListAsync();
            return lessons;
        }

        public async Task<ActionResult<LessonDto>> GetLessonById(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            return _mapper.Map<LessonDto>(lesson);
        }

        public async Task<LessonDto> UpdateLesson(LessonDto lessonDto, int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return null;
            }
            lesson.LessonName = lessonDto.LessonName;
            await _context.SaveChangesAsync();
            var lessonEntity = _mapper.Map<LessonDto>(lesson);
            return lessonEntity;
        }
        public async Task<bool> DeleteLesson(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return false;
            }
            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
