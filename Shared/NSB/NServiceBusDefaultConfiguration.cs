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

            container.Configure(
                cfg =>
                {                                
                    cfg.Policies.FillAllPropertiesOfType<IContainer>();
                    cfg.For<IManageUnitsOfWork>().Use<NSBUnitOfWorkManager>();
                }
                );

            configuration.UseContainer<StructureMapBuilder>(c => c.ExistingContainer(container));
           
            configuration.UsePersistence<NHibernatePersistence>();
            //configuration.Transactions().DisableDistributedTransactions();
        }
    }
}
