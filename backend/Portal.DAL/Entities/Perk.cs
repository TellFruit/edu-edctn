﻿using Portal.DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.DAL.Entities
{
    public class Perk : BaseEntity
    {
        public string Name { get; set; }
        public Scope Scope { get; set; }
    }
}