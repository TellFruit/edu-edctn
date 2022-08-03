using Portal.DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.DAL.Entities
{
    public class Article : Material
    {
        public string Url { get; set; }
        public DateTime Published { get; set; }
    }
}
