namespace Business.Response.Applications
{
    public class GetApplicationResponse
    {
        public Guid Id { get; set; }
        public string ApplicantUserName { get; set; }
        public string ApplicantFirstName { get; set; }
        public string ApplicantLastName { get; set; }
        public string ApplicantEmail { get; set; }
        public Guid ApplicantId { get; set; }
        public Guid BootcampId { get; set; }
        public Guid ApplicationStateId { get; set; }
    }
}
