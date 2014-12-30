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
    public static class NServiceBusDefaultTestConfiguration
    {
        public static void SetDefaultTestConfiguration(this BusConfiguration configuration, IContainer container)
        {      

            configuration.UseContainer<StructureMapBuilder>(c => c.ExistingContainer(container));


        }
    }
}
