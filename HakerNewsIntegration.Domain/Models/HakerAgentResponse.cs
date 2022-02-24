namespace HakerNewsIntegration.Domain.Models
{
    public class HakerAgentResponse
    {
        public string By { get; set; }
        public long Descendants { get; set; }
        public long Id { get; set; }
        public IEnumerable<string> Kids { get; set; }
        public long Score { get; set; }
        public long Time { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
    }
}
