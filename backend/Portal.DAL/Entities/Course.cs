using Portal.DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.DAL.Entities
{
    public class Course : BaseEntity
    {
        public Course()
        {
            Materials = new List<Material>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public User Author { get; set; }
        public ICollection<Material> Materials { get; set; }
    }
}
