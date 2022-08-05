using Portal.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<string> Roles { get; set; }

        public ICollection<UserPerk> UserPerks { get; set; }
        public ICollection<Material> Materials { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
