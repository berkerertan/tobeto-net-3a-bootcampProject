using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Response.Bootcamps
{
    public class CreateBootcampResponse
    {
        public string Name { get; set; }
        public Guid InstructorId { get; set; }
        public Guid BootcampStateId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
