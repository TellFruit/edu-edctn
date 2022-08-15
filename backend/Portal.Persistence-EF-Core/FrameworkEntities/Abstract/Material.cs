﻿using Portal.Persistence_EF_Core.FrameworkEntities;

namespace Portal.Persitence_EF_Core.FrameworkEntities.Abstract
{
    internal class Material : FrameworkEntity
    {
        public string Title { get; set; }

        public ICollection<Perk> Perks { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Course> Courses { get; set; }

        public ICollection<MaterialPerk> MaterialPerks { get; set; }
        public ICollection<UserMaterial> UserMaterials { get; set; }
        public ICollection<CourseMaterial> CourseMaterials { get; set; }
    }
}
