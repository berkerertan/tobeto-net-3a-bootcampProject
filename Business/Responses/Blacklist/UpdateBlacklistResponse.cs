using Entities.Concretes;

namespace Business.Responses.Blacklist
{
    public class UpdateBlacklistResponse
    {
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public Guid AplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}
