using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.MappingProfiles
{
    internal class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(b => b.Perks, opt => opt.MapFrom(src => src.Perks));

            CreateMap<BookDTO, Book>()
                .ForMember(b => b.Perks, opt => opt.MapFrom(src => src.Perks));
        }
    }
}
