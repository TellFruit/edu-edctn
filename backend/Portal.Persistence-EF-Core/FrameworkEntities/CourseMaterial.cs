namespace Portal.Persistence_EF_Core.FrameworkEntities
{
    internal class CourseMaterial
    {
        public int CourseId { get; set; }
        public int MaterialId { get; set; }

        // [ForeignKey("CourseId")]
        public Course Course { get; set; }
        
        // [ForeignKey("MaterialId")]
        public Material Material { get; set; }
    }
}
