using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.DAL.Entities
{
    public class UserPerk
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public Perk Perk { get; set; }
    }
}
