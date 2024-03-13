using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Entities
{
    public class OperationClaim : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
        public OperationClaim() 
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
        }

        public OperationClaim(Guid id, string name):this()
        {
            Id = id;
            Name = name;
        }
    }
}
