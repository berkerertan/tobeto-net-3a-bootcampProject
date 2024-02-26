namespace Business.Response.Bootcamps
{
    public class UpdateBootcampResponse
    {
        public string Name { get; set; }
        public Guid InstructorId { get; set; }
        public Guid BootcampStateId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
