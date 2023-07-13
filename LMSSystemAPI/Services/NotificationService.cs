using AutoMapper;
using LMSSystemAPI.Dbcontext;
using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSSystemAPI.Services
{
    public class NotificationService : INotificationService
    {
        private readonly LMSSystemContext _context;
        private readonly IMapper _mapper;
        public NotificationService(LMSSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Notification> CreateNotification(NotificationDto notificationDto)
        {
            var notificationEntity = _mapper.Map<Notification>(notificationDto);
            _context.Notifications.Add(notificationEntity);
            await _context.SaveChangesAsync();
            return notificationEntity;
        }

        public async Task<ActionResult<IEnumerable<NotificationDto>>> GetNotifications()
        {
            var notification = await _context.Notifications.Select(x => _mapper.Map<NotificationDto>(x)).ToListAsync();
            return notification;
        }
    }
}
