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
    public class CommandAHandler : IHandleMessages<CommandA>
    {
        private IBus bus;

        private IDomainUnitOfWork domainUoW;

        private IService1Factory service1Factory;

        public CommandAHandler(IDomainUnitOfWork uow, IBus bus, IService1Factory service1Factory)
        {
            domainUoW = uow;
            this.bus = bus;
            this.service1Factory = service1Factory;
        }
       
        public void Handle(CommandA message)
        {
            var service1 = service1Factory.CreateService("VENDORX");

            service1.DoSomething();

        }
    }
}
