using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMSSystemAPI.Services.IServices
{
    public interface IRoleService
    {
        public Task<Role> CreateRole(RoleDto roleDto);
        public Task<ActionResult<IEnumerable<RoleDto>>> GetRoles();
        public Task<ActionResult<RoleDto>> GetRoleById(int id);
        public Task<RoleDto> UpdateRole(RoleDto roleDto, int id);
        public Task<bool> DeleteRole(int id);
    }
}
