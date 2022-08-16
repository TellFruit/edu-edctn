using Portal.Persitence_EF_Core.FrameworkEntities;
using Portal.Persitence_EF_Core.FrameworkEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Persistence_EF_Core.FrameworkEntities
{
    internal class MaterialPerk
    {
        public int PerkId { get; set; }
        public int MaterialId { get; set; }

        public Perk Perk { get; set; }
        public Material Material { get; set; }
    }
}
