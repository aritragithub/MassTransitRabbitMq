using MassTransit;
using MassTransitRabbitMq.DTO;
using MassTransitRabbitMq.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MassTransitRabbitMq.Controller
{
    [Route("api/massTransit")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public NotificationController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;

        }

        [HttpPost]
        [Route("notification")]
        public async Task<IActionResult> ProduceNotification([FromBody] NotificationDTO dto)
        {
           await _publishEndpoint.Publish<Notification>(new Notification
           {
               Id = dto.Id,
               CreationDate = dto.CreationDate,
               Type = dto.Type
           });

            return Ok();
        }
    }
}
