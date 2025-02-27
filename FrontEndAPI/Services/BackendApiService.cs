using FrontEndAPI.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FrontEndAPI.Services
{
    public interface IBackendApiService
    {
        Task<object> GetDataFromApi2Async();
        Task<object> GetDataFromApi3Async();
        Task<object> PostToApi2Async(object request);
        Task<object> PostToApi3Async(object request);
    }

    public class BackendApiService : IBackendApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<BackendApiService> _logger;
        private readonly IConfiguration _configuration;

        public BackendApiService(
            HttpClient httpClient,
            ILogger<BackendApiService> logger,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<object> GetDataFromApi2Async()
        {
            _logger.LogInformation("Calling API2 GET endpoint");
            string api2Url = _configuration["BackendServices:Api2Url"];
            var response = await _httpClient.GetFromJsonAsync<object>($"{api2Url}/api/data");
            return response;
        }

        public async Task<object> GetDataFromApi3Async()
        {
            _logger.LogInformation("Calling API3 GET endpoint");
            string api3Url = _configuration["BackendServices:Api3Url"];
            var response = await _httpClient.GetFromJsonAsync<object>($"{api3Url}/api/reports");
            return response;
        }

        public async Task<object> PostToApi2Async(object request)
        {
            _logger.LogInformation("Calling API2 POST endpoint");
            string api2Url = _configuration["BackendServices:Api2Url"];
            var response = await _httpClient.PostAsJsonAsync($"{api2Url}/api/data", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<object>();
        }

        public async Task<object> PostToApi3Async(object request)
        {
            _logger.LogInformation("Calling API3 POST endpoint");
            string api3Url = _configuration["BackendServices:Api3Url"];
            var response = await _httpClient.PostAsJsonAsync($"{api3Url}/api/reports", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<object>();
        }
    }
}
