using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;

        public DataController(ILogger<DataController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("API2 GET request received");

            // Artificial delay to simulate longer running operation (2 seconds)
            await Task.Delay(2000);

            var data = new
            {
                Source = "API2",
                Timestamp = DateTime.UtcNow,
                Data = new[] { "Item1", "Item2", "Item3" }
            };

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] object request)
        {
            _logger.LogInformation("API2 POST request received");

            // Artificial delay to simulate longer running operation (3 seconds)
            await Task.Delay(3000);

            var response = new
            {
                Source = "API2",
                Timestamp = DateTime.UtcNow,
                Status = "Processed",
                OriginalRequest = request
            };

            return Ok(response);
        }
    }
}
