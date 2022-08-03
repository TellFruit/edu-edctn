﻿using Portal.Domain.Entities.Abstract;
using System.Collections;

namespace Portal.Domain.Entities
{
    public class Book : Material
    {
        public int PageCount { get; set; }
        public string Format { get; set; }
        public DateTime Published { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
