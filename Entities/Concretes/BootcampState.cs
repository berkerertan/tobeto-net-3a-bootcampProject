using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class BootcampState : BaseEntity<Guid>
    {
        public BootcampState()
        {
        }

        public BootcampState(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
