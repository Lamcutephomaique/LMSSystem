using AutoMapper;
using LMSSystemAPI.Dbcontext;
using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMSSystemAPI.Services.IServices
{
    public interface IFacultyService
    {
        public Task<Faculty> CreateFaculty(FacultyDto facultyDto);
        public Task<ActionResult<IEnumerable<FacultyDto>>> GetFacultys();
        public Task<ActionResult<FacultyDto>> GetFacultyById(int id);
        public Task<FacultyDto> UpdateFaculty(FacultyDto facultyDto, int id);
        public Task<bool> DeleteFaculty(int id);
    }
}
