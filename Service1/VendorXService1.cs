using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;
using NServiceBus;
using Shared.NHibernate;

namespace Service1
{
    public class VendorXService1 : IService1
    {
        private IDomainUnitOfWork domainUoW;

        private IBus bus;


        public VendorXService1(IDomainUnitOfWork uow, IBus bus)
        {
            this.domainUoW = uow;

            this.bus = bus;
        }

        public void DoSomething()
        {           

            domainUoW.GetARepository().Add(new A() { Name="Paco"});
        }
    }
}
