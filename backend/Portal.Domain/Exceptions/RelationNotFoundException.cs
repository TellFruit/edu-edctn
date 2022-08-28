using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Exceptions
{
    public class RelationNotFoundException : Exception
    {
        public RelationNotFoundException(string name)
            : base($"Relation named ({name}) not found!") { }
    }
}
