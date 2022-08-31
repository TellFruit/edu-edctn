﻿namespace Portal.Application.DTO
{
    public class PerkLevelDTO
    {
        public int UserId { get; set; }
        public int PerkId { get; set; }
        public int Level { get; set; }

        public UserDTO User { get; set; }
        public PerkDTO Perk { get; set; }
    }
}
