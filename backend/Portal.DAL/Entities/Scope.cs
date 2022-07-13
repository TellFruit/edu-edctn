using Portal.DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.DAL.Entities
{
    public class Scope : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
