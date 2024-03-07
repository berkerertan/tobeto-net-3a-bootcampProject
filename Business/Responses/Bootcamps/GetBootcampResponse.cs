namespace Business.Response.Bootcamps
{
    public class GetBootcampResponse
    {
        public Guid Id { get; set; }
        public string InstructorUserName { get; set; }
        public string InstructorFirstName { get; set; }
        public string InstructorLastName { get; set; }
        public string InstructorEmail { get; set; }
        public Guid InstructorId { get; set; }
        public Guid BootcampStateId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
