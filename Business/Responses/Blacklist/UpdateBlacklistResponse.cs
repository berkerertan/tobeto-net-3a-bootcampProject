using Entities.Concretes;

namespace Business.Responses.Blacklist
{
    public class UpdateBlacklistResponse
    {
        public Guid Id { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public Guid AplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}
