using Portal.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class Scope : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Material> Materials { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Perk> Perks { get; set; }

    }
}
