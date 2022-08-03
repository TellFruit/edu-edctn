using Portal.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class Perk : BaseEntity
    {
        public string Name { get; set; }
        
        public Scope Scope { get; set; }
        public ICollection<UserPerk> UserPerks { get; set; }
        public ICollection<Material> Materials { get; set; }

    }
}
