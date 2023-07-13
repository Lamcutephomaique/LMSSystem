using AutoMapper;
using LMSSystemAPI.Dbcontext;
using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LMSSystemAPI.Services
{
    public class RoleService : IRoleService
    {
        private readonly LMSSystemContext _context;
        private readonly IMapper _mapper;
        public RoleService(LMSSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Role> CreateRole(RoleDto roleDto)
        {
            var roleEntity = _mapper.Map<Role>(roleDto);
            _context.Roles.Add(roleEntity);
            await _context.SaveChangesAsync();
            return roleEntity;
        }

        public async Task<ActionResult<IEnumerable<RoleDto>>> GetRoles()
        {
            var roles = await _context.Roles.Select(x => _mapper.Map<RoleDto>(x)).ToListAsync();
            return roles;
        }

        public async Task<ActionResult<RoleDto>> GetRoleById(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            return _mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> UpdateRole(RoleDto roleDto, int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return null;
            }         
            role.RoleName = roleDto.RoleName;                   
            await _context.SaveChangesAsync();
            var roleEntity = _mapper.Map<RoleDto>(role);
            return roleEntity;
        }
        public async Task<bool> DeleteRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return false;
            }
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();         
            return true;
        }

    }
}
