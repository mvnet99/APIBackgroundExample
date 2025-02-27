namespace FrontEndAPI.Models
{
    public class AggregateResponse
    {
        public DateTime RequestTime { get; set; }
        public DateTime ResponseTime { get; set; }
        public TimeSpan TotalProcessingTime { get; set; }
        public object Api2Response { get; set; }
        public object Api3Response { get; set; }
    }
}
