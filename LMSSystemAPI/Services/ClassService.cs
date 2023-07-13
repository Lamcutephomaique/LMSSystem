using AutoMapper;
using LMSSystemAPI.Dbcontext;
using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSSystemAPI.Services
{
    public class ClassService : IClassService
    {
        private readonly LMSSystemContext _context;
        private readonly IMapper _mapper;
        public ClassService(LMSSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Class> CreateClass(ClassDto classDto)
        {
            var classEntity = _mapper.Map<Class>(classDto);
            _context.Classes.Add(classEntity);
            await _context.SaveChangesAsync();
            return classEntity;
        }

        public async Task<ActionResult<IEnumerable<ClassDto>>> GetClasses()
        {
            var classs = await _context.Classes.Select(x => _mapper.Map<ClassDto>(x)).ToListAsync();
            return classs;
        }

        public async Task<ActionResult<ClassDto>> GetClassById(int id)
        {
            var classs = await _context.Classes.FindAsync(id);
            return _mapper.Map<ClassDto>(classs);
        }

        public async Task<ClassDto> UpdateClass(ClassDto classDto, int id)
        {
            var classs = await _context.Classes.FindAsync(id);
            if (classs == null)
            {
                return null;
            }
            classs.ClassName = classDto.ClassName;
            await _context.SaveChangesAsync();
            var classEntity = _mapper.Map<ClassDto>(classs);
            return classEntity;
        }
        public async Task<bool> DeleteClass(int id)
        {
            var classs = await _context.Classes.FindAsync(id);
            if (classs == null)
            {
                return false;
            }
            _context.Classes.Remove(classs);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
