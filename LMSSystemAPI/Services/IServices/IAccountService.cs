using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LMSSystemAPI.Services.IServices
{
    public interface IAccountService
    {
        public Task<List<UserDto>> GetAllAccountAsync();

        public Task<User> register(UserDto userDto);
        public Task<string> Login(UserLoginDto userLoginDto);
    }
}
