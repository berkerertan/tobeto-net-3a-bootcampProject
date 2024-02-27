namespace Business.Requests.Blacklist
{
    public class GetBlacklistRequest
    {
        public Guid Id { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
    }
}
