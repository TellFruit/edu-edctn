﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class UserPerk
    {
        public int Id { get; set; }
        public int Level { get; set; }

        public Perk Perk { get; set; }
        public User User { get; set; }
    }
}
