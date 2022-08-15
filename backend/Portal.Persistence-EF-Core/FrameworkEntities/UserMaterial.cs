using Portal.Persitence_EF_Core.FrameworkEntities;
using Portal.Persitence_EF_Core.FrameworkEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Persistence_EF_Core.FrameworkEntities
{
    internal class UserMaterial
    {
        public int UserId { get; set; }
        public int MaterialId { get; set; }

        public User User { get; set; }
        public Material Material { get; set; }
    }
}
