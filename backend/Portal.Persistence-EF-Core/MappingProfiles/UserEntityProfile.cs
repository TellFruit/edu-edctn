using AutoMapper;
using Portal.Domain.Entities;
using Portal.Persitence_EF_Core.FrameworkEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Persistence_EF_Core.MappingProfiles
{
    internal class UserEntityProfile : Profile
    {
        public UserEntityProfile()
        {
            CreateMap<UserDomain, User>();

            CreateMap<User, UserDomain>();
        }
    }
}
