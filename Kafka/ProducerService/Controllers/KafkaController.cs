using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProducerService.Services;

namespace ProducerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KafkaController : ControllerBase
    {
        private readonly KafkaProducerService _producerService;
        public KafkaController(KafkaProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpGet]
        public IActionResult Get() {
            return Ok("hola");
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromQuery] string key, [FromQuery] string message)
        {
            Console.WriteLine("Key: {Key}, Message: {Message}.", key, message);
            await _producerService.SendMessageAsync("my-topic", key, message);
            return Ok("Message sent");
        }
    }
}