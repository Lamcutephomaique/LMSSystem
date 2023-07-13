using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSSystemAPI.Services.IServices
{
    public interface IUserCourseService
    {
        public Task<UserCourse> CreateUserCourse(UserCourseDto userCourseDto);

        public Task<ActionResult<IEnumerable<UserCourseDto>>> GetUserCourses();

    }
}
