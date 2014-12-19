using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.UnitOfWork;
using Shared.NHibernate;
using StructureMap;
using StructureMap.Graph;

namespace Shared
{
    public static class NServiceBusDefaultConfiguration
    {
        public static void SetDefaultConfiguration(this BusConfiguration configuration, IContainer container)
        {
           /* 
            var container = new Container(cfg =>
                {                                 
                    cfg.For<IManageUnitsOfWork>().Use<NSBUnitOfWorkManager>();
                    cfg.Policies.FillAllPropertiesOfType<IUnitOfWork>().Use<UnitOfWork>();
                    cfg.Policies.FillAllPropertiesOfType<IUnitOfWork>().Use<UnitOfWork>();
                    cfg.Policies.FillAllPropertiesOfType<IContainer>();
                });
            */

            container.Configure(
                cfg =>
                {
                    cfg.For<IManageUnitsOfWork>().Use<NSBUnitOfWorkManager>();
                    cfg.Policies.FillAllPropertiesOfType<IUnitOfWork>().Use<UnitOfWork>();
                    cfg.Policies.FillAllPropertiesOfType<IUnitOfWork>().Use<UnitOfWork>();
                    cfg.Policies.FillAllPropertiesOfType<IContainer>();
                }
                );

            configuration.UseContainer<StructureMapBuilder>(c => c.ExistingContainer(container));
           

            configuration.UsePersistence<NHibernatePersistence>();                                   
          
        }
    }
}
