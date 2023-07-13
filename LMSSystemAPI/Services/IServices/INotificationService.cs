using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMSSystemAPI.Services.IServices
{
    public interface INotificationService
    {
        public Task<Notification> CreateNotification(NotificationDto notificationDto);
        public Task<ActionResult<IEnumerable<NotificationDto>>> GetNotifications();
    }
}
