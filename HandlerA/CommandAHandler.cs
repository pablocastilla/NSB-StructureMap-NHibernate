using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages;
using NServiceBus;
using Service1;
using Shared.NHibernate;
using StructureMap;


namespace HandlerA
{
    public class CommandAHandler : IHandleMessages<CommandA>
    {
        public IBus Bus { get; set; }

        public IUnitOfWork UoW { get; set; }

        public IContainer Container { get; set; }

        public IService1 Service1 { get; set; }

       
        public void Handle(CommandA message)
        {
           // throw new NotImplementedException();
        }
    }
}
