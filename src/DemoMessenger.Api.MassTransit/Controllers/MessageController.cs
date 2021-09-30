using DemoMessenger.Domain.Configurations;
using DemoMessenger.Domain.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace DemoMessenger.Api.MassTransit.Controllers
{
    [Route("api/v1/[controller]")]
    public class MessageController : Controller
    {
        private readonly IBus _bus;
        private readonly RabbitMqConfigMassTransit _configuration;

        public MessageController(IOptions<RabbitMqConfigMassTransit> option, IBus bus)
        {
            _configuration = option.Value;
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> PostMessage([FromBody] Message message)
        {
            if (ModelState.IsValid)
            {
                Uri uri = new Uri(_configuration.RabbitMqUri);
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(message);
                return Ok();
            }
            return BadRequest();
        }
    }
}
