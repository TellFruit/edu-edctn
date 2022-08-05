using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Exceptions
{
    internal class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string name)
            : base($"Entity of type ({name}) not found!")
        {
        }
    }
}
