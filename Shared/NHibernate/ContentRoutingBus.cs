using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace Shared.NHibernate
{
    public static class ContentRoutingBus
    {
        public static ICallback ContentRoutingSend(this IBus bus, object message)
        {
            return bus.Send(message);
        }
    }
}
