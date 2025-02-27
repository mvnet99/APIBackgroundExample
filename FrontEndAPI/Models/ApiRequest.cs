namespace FrontEndAPI.Models
{
    public class ApiRequest
    {
        public string RequestId { get; set; } = Guid.NewGuid().ToString();
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string ClientInfo { get; set; }
        public object Payload { get; set; }
    }
}
