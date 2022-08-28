﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Exceptions
{
    public class RelationAlreadyExists : Exception
    {
        public RelationAlreadyExists(string name)
            : base($"Relation named ({name}) already exists!") { }
    }
}
