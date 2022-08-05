using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities.Abstract
{
    public abstract class Material : BaseEntity
    {
        public string Title { get; set; }

        public ICollection<Perk> Perks { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Course> Courses { get; set; }

    }
}
