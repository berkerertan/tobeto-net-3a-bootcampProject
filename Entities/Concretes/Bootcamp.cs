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
