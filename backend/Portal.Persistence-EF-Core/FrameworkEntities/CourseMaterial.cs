using Portal.Persitence_EF_Core.FrameworkEntities;
using Portal.Persitence_EF_Core.FrameworkEntities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
