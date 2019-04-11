using AutoMapper;
using BaseJWT.Service.Convertions;
using BaseJWT.Service.Injection;
using BaseJWT.Util.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BaseJWT.Services
{
    public class AppServiceSetup
    {
        public void Set(IServiceCollection services, IConfiguration configuration)
        {

            IocInfrastructure.Set(services, configuration);

            AutoMapperSet(services);

            StartDomainHandlers(services);
        }

        void StartDomainHandlers(IServiceCollection services)
        {
            DomainEvents.Init(services);
        }

        void AutoMapperSet(IServiceCollection services)
        {
            var profiles = new List<Assembly>
            {
                typeof(DomainEntityToDtoProfile).Assembly,
                typeof(DtoToDomainEntityProfile).Assembly
            };

            Mapper.Initialize(a => a.AddProfiles(profiles));
            services.AddSingleton(Mapper.Instance);
        }
    }
}
