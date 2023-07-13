using LMSSystemAPI.Dtos;
using LMSSystemAPI.Helpers;
using LMSSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LMSSystemAPI.Services.IServices
{
    public interface ITeacherService
    {
        public Task<List<TeacherDto>> GetAllAccountTeacherAsync();
        public Task<Teacher> register(TeacherDto teacherDto);
        public Task<string> Login(TeacherLoginDto teacherLoginDto);     
    }
}
