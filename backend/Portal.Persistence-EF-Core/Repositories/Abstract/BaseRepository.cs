using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Persistence_EF_Core.Repositories.Abstract
{
    internal abstract class BaseRepository
    {
        protected readonly IMapper _mapper;
        protected readonly PortalContext _context;

        public BaseRepository(IMapper mapper, PortalContext context)
        {
            _mapper = mapper;
            _context = context;
        }
    }
}
