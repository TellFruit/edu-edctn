using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string Format { get; set; }
        public DateTime Published { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
