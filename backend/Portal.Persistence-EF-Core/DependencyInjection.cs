using Microsoft.Extensions.DependencyInjection;
using Portal.Application.Interfaces.OuterImpl;
using Portal.Domain.Entities;
using Portal.Persistence_EF_Core.MappingProfiles;
using Portal.Persistence_EF_Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Persistence_EF_Core
{
    public static class DependencyInjection
    {
        public static void RegisterApplication(IServiceCollection services)
        {
            services.AddAutoMapper(
                cfg =>
                {
                    cfg.AddProfile<UserEntityProfile>();
                },
            Assembly.GetExecutingAssembly());

            services.AddScoped<IGenericRepository<UserDomain>, UserRepository>();
        }
    }
}
