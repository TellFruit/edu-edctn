using Portal.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class Video : Material
    {
        public TimeSpan Duration { get; set; }
        public int Quality { get; set; }
    }
}
