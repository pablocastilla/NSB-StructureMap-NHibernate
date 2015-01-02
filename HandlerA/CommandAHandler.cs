using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Messages;
using NServiceBus;
using Service1;
using Shared.NHibernate;
using StructureMap;


namespace HandlerA
{
    /// <summary>
    /// Handler that processes a CommandA.
    /// </summary>
    public class CommandAHandler : IHandleMessages<CommandA>
    {
        private IBus bus;        

        /// <summary>
        /// Service1 locator. The service needs to be resolved at runtime by vendor.
        /// </summary>
        private IService1ServiceLocator service1ServiceLocator;

        public CommandAHandler(IBus bus, IService1ServiceLocator service1ServiceLocator)
        {
            if (bus == null)
                throw new ArgumentNullException("IBus dependency is null");

            if (service1ServiceLocator == null)
                throw new ArgumentNullException("IService1ServiceLocator dependency is null");

            this.bus = bus;
            this.service1ServiceLocator = service1ServiceLocator;
        }
       
        public void Handle(CommandA message)
        {
            var service1 = service1ServiceLocator.CreateService("VENDORX");

            service1.DoSomething(message.Name);

        }
    }
}
