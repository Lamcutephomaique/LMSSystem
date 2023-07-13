using AutoMapper;
using LMSSystemAPI.Dbcontext;
using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSSystemAPI.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly LMSSystemContext _context;
        private readonly IMapper _mapper;
        public FacultyService(LMSSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Faculty> CreateFaculty(FacultyDto facultyDto)
        {
            var facultyEntity = _mapper.Map<Faculty>(facultyDto);
            _context.Facultys.Add(facultyEntity);
            await _context.SaveChangesAsync();
            return facultyEntity;
        }

        public async Task<ActionResult<IEnumerable<FacultyDto>>> GetFacultys()
        {
            var roles = await _context.Facultys.Select(x => _mapper.Map<FacultyDto>(x)).ToListAsync();
            return roles;
        }

        public async Task<ActionResult<FacultyDto>> GetFacultyById(int id)
        {
            var Faculty = await _context.Facultys.FindAsync(id);
            return _mapper.Map<FacultyDto>(Faculty);
        }

        public async Task<FacultyDto> UpdateFaculty(FacultyDto facultyDto, int id)
        {
            var faculty = await _context.Facultys.FindAsync(id);
            if (faculty == null)
            {
                return null;
            }
            faculty.FacultytName = facultyDto.FacultytName;
            await _context.SaveChangesAsync();
            var facultyEntity = _mapper.Map<FacultyDto>(faculty);
            return facultyEntity;
        }
        public async Task<bool> DeleteFaculty(int id)
        {
            var faculty = await _context.Facultys.FindAsync(id);
            if (faculty == null)
            {
                return false;
            }
            _context.Facultys.Remove(faculty);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
