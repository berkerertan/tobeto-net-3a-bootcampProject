namespace Business.Requests.Applications
{
    public class UpdateApplicationRequest
    {
        public Guid Id { get; set; }
        public Guid ApplicantId { get; set; }
        public Guid BootcampId { get; set; }
        public Guid ApplicationStateId { get; set; }
    }
}
