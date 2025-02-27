namespace FrontEndAPI.Models
{
    public class ApiResponse
    {
        public string Source { get; set; }
        public DateTime Timestamp { get; set; }
        public object Data { get; set; }
    }
}
