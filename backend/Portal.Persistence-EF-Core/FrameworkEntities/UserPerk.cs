﻿namespace Portal.Persitence_EF_Core.FrameworkEntities
{
    internal class UserPerk
    {
        public int Id { get; set; }
        public int Level { get; set; }

        public Perk Perk { get; set; }
        public User User { get; set; }
    }
}