using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ILogger<ReportsController> _logger;

        public ReportsController(ILogger<ReportsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("API3 GET request received");

            // Artificial delay to simulate longer running operation (4 seconds)
            await Task.Delay(4000);

            var report = new
            {
                Source = "API3",
                Timestamp = DateTime.UtcNow,
                ReportName = "Summary Report",
                Metrics = new
                {
                    TotalUsers = 1250,
                    ActiveUsers = 843,
                    NewRegistrations = 125
                }
            };

            return Ok(report);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] object request)
        {
            _logger.LogInformation("API3 POST request received");

            // Artificial delay to simulate longer running operation (5 seconds)
            await Task.Delay(5000);

            var response = new
            {
                Source = "API3",
                Timestamp = DateTime.UtcNow,
                ReportStatus = "Generated",
                ReportId = Guid.NewGuid().ToString(),
                OriginalRequest = request
            };

            return Ok(response);
        }
    }
}
