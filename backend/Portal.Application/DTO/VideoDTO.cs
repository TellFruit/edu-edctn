using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.DTO
{
    public class VideoDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public int Quality { get; set; }
        public ICollection<Perk> Perks { get; set; }
    }
}
