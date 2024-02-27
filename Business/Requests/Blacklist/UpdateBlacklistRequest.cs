namespace Business.Requests.Blacklist
{
    public class UpdateBlacklistRequest
    {
        public Guid Id { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
    }
}
