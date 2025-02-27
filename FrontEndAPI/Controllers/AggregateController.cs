using FrontEndAPI.Models;
using FrontEndAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


// Controllers/AggregateController.cs
namespace FrontEndAPI.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Require authentication for all endpoints
    public class AggregateController : ControllerBase
    {
        private readonly IBackendApiService _backendApiService;
        private readonly ILogger<AggregateController> _logger;

        public AggregateController(
            IBackendApiService backendApiService,
            ILogger<AggregateController> logger)
        {
            _backendApiService = backendApiService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Aggregate GET request received from user: {User}", User.Identity.Name);

            var stopwatch = Stopwatch.StartNew();
            var requestTime = DateTime.UtcNow;

            // Call both APIs asynchronously
            var api2Task = _backendApiService.GetDataFromApi2Async();
            var api3Task = _backendApiService.GetDataFromApi3Async();

            // Wait for both tasks to complete
            await Task.WhenAll(api2Task, api3Task);

            stopwatch.Stop();
            var responseTime = DateTime.UtcNow;

            var response = new AggregateResponse
            {
                RequestTime = requestTime,
                ResponseTime = responseTime,
                TotalProcessingTime = stopwatch.Elapsed,
                Api2Response = api2Task.Result,
                Api3Response = api3Task.Result
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ApiRequest request)
        {
            _logger.LogInformation("Aggregate POST request received from user: {User}", User.Identity.Name);

            var stopwatch = Stopwatch.StartNew();
            var requestTime = DateTime.UtcNow;

            // Call both APIs asynchronously
            var api2Task = _backendApiService.PostToApi2Async(request);
            var api3Task = _backendApiService.PostToApi3Async(request);

            // Wait for both tasks to complete
            await Task.WhenAll(api2Task, api3Task);

            stopwatch.Stop();
            var responseTime = DateTime.UtcNow;

            var response = new AggregateResponse
            {
                RequestTime = requestTime,
                ResponseTime = responseTime,
                TotalProcessingTime = stopwatch.Elapsed,
                Api2Response = api2Task.Result,
                Api3Response = api3Task.Result
            };

            return Ok(response);
        }
    }
}