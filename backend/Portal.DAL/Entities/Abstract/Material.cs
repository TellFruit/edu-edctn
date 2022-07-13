using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.DAL.Entities.Abstract
{
    public abstract class Material : BaseEntity
    {
        public string Title { get; set; }
    }
}
