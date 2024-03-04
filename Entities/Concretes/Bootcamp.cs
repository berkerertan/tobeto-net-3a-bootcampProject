using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Bootcamp : BaseEntity<Guid>
    {
        public Bootcamp()
        {
            
        }

        public Bootcamp(string name, Guid ınstructorId, Guid bootcampStateId, DateTime startDate, DateTime endDate, BootcampState bootcampState, ICollection<Application> applications, Instructor ınstructor)
        {
            Name = name;
            InstructorId = ınstructorId;
            BootcampStateId = bootcampStateId;
            StartDate = startDate;
            EndDate = endDate;
            BootcampState = bootcampState;
            Applications = applications;
            Instructor = ınstructor;
        }

        public string Name { get; set; }
        public Guid InstructorId { get; set; }
        public Guid BootcampStateId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public BootcampState BootcampState { get; set; }
        public ICollection<Application> Applications { get; set; }
        public Instructor Instructor { get; set; }

    }
}
