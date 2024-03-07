using Entities.Concretes;

namespace Business.Responses.Blacklist
{
    public class GetBlacklistResponse
    {
        public Guid Id { get; set; }
        public string AplicantUserName { get; set; }
        public string AplicantFirstName { get; set; }
        public string AplicantLastName { get; set; }
        public string AplicantEmail { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public Guid AplicantId { get; set; }
        //public Applicant Applicant { get; set; }
    }
}
