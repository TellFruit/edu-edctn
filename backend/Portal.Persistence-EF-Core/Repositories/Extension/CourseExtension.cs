namespace Portal.Persistence_EF_Core.Repositories.Extension
{
    internal static class CourseExtension
    {
        public static ICollection<CourseMaterial> ToCourseMaterials(this ICollection<MaterialDomain> materials)
        {
            var courseMaterials = new List<CourseMaterial>();

            foreach (var material in materials)
            {
                courseMaterials.Add(new CourseMaterial
                {
                    MaterialId = material.Id
                });
            }

            return courseMaterials;
        }

        public static ICollection<CoursePerk> ToCoursePerks(this ICollection<PerkDomain> perks)
        {
            var coursePerks = new List<CoursePerk>();

            foreach (var perk in perks)
            {
                coursePerks.Add(new CoursePerk
                {
                    PerkId = perk.Id
                });
            }

            return coursePerks;
        }

        public static ICollection<CourseMaterial> ToCourseMaterials(this ICollection<MaterialDomain> materials, int courseId)
        {
            return materials
                .Select(m => new CourseMaterial
                {
                    CourseId = courseId,
                    MaterialId = m.Id
                })
                .ToList();
        }

        public static ICollection<CoursePerk> ToCoursePerks(this ICollection<PerkDomain> perks, int courseId)
        {
            return perks
                .Select(p => new CoursePerk
                {
                    CourseId = courseId,
                    PerkId = p.Id
                })
                .ToList();
        }

        public static void MapFromCourseDomain(this Course course, CourseDomain data, ICollection<CourseMaterial> materials, ICollection<CoursePerk> perks)
        {
            course.Name = data.Name;
            course.Description = data.Description;
            course.UpdatedAt = data.UpdatedAt;
            course.CourseMaterials = materials;
            course.CoursePerks = perks;
        }
    }
}
