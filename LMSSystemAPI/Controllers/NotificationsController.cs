using LMSSystemAPI.Dtos;
using LMSSystemAPI.Services;
using LMSSystemAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicDto>>> GetAllTopic()
        {
            try
            {
                var notification = await _notificationService.GetNotifications();
                if (notification == null)
                {
                    return BadRequest("Null");
                }
                return Ok(notification);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<NotificationDto>> CreateNotification(NotificationDto notificationDto)
        {
            var notification = await _notificationService.CreateNotification(notificationDto);
            if (notification == null)
            {
                return BadRequest("Null");
            }
            return Ok(notification);
        }

    }
}
