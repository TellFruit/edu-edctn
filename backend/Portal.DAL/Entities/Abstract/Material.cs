using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.DAL.Entities.Abstract
{
    public abstract class Material : BaseEntity
    {
        public Material()
        {
            Perks = new List<Perk>();
        }

        public string Title { get; set; }
        public ICollection<Perk> Perks { get; set; }
    }
}
