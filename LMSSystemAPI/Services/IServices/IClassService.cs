using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSSystemAPI.Services.IServices
{
    public interface IClassService
    {
        public Task<Class> CreateClass(ClassDto classDto);
        public Task<ActionResult<IEnumerable<ClassDto>>> GetClasses();
        public Task<ActionResult<ClassDto>> GetClassById(int id);
        public Task<ClassDto> UpdateClass(ClassDto classDto, int id);
        public Task<bool> DeleteClass(int id);      
    }
}
