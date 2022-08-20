﻿using Portal.Domain.Entities.Abstract;

namespace Portal.Domain.Entities
{
    public class BookDomain : MaterialDomain
    {
        public int PageCount { get; set; }
        public string Format { get; set; }
        public DateTime Published { get; set; }
        public string Authors { get; set; }
    }
}
