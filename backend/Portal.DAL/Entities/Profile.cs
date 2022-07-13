using Portal.DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.DAL.Entities
{
    public class Profile
    {
        public Profile()
        {
            ChosenCourses = new List<Course>();
            LearnedMaterials = new List<Material>();
            AttainedPerks = new List<UserPerk>();
        }
        public User User { get; set; }
        public ICollection<Course> ChosenCourses { get; private set; }
        public ICollection<Material> LearnedMaterials { get; private set; }
        public ICollection<UserPerk> AttainedPerks { get; private set; }
    }
}
