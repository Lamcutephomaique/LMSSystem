using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSSystemAPI.Services.IServices
{
    public interface ILessonService
    {
        public  Task<Lesson> CreateLesson(LessonDto lessonDto);


        public  Task<ActionResult<IEnumerable<LessonDto>>> GetLessons();


        public  Task<ActionResult<LessonDto>> GetLessonById(int id);

        public  Task<LessonDto> UpdateLesson(LessonDto lessonDto, int id);

        public Task<bool> DeleteLesson(int id);
      
    }
}
