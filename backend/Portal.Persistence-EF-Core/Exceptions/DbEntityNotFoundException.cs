using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Persistence_EF_Core.Exceptions
{
    internal class DbEntityNotFoundException : Exception
    {
        public DbEntityNotFoundException(string type)
            : base($"Database entity of type ({type}) not found!") { }
    }
}
