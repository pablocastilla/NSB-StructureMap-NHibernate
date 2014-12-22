using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories;
using NServiceBus;
using NServiceBus.UnitOfWork;
using Shared;
using Shared.NHibernate;
using StructureMap;
using StructureMap.Pipeline;

namespace Domain
{
    public static class NSBDefaultDomainConfiguration
    {
        public static void SetDefaultDomainConfiguration(this BusConfiguration configuration, IContainer container)
        {
            
            container.Configure(
                cfg =>
                {                    
                    cfg.Policies.FillAllPropertiesOfType<IDomainUnitOfWork>().Use<DomainUnitOfWork>();
                    cfg.Forward<IDomainUnitOfWork,IUnitOfWork>();
                    cfg.Policies.FillAllPropertiesOfType<IUnitOfWork>();
                    cfg.Policies.FillAllPropertiesOfType<IARepository>().Use<ARepository>();
                    cfg.For<ISessionFactoryCreator>().Use<DomainSessionFactoryCreator>();    
                  
                                     
                    cfg.For<IManageUnitsOfWork>().Use<NSBUnitOfWorkManager>();               
                                 
                }
                );

         
        }
    }
}
