using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;
using NServiceBus;
using Service1.DataAccess;
using Shared.NHibernate;

namespace Service1
{
    public class VendorXService1 : IService1
    {
        private IServiceXUoW uow;

        private IBus bus;


        public VendorXService1(IServiceXUoW uow, IBus bus)
        {
            this.uow = uow;

            this.bus = bus;
        }

        public void DoSomething(string name)
        {

            uow.GetAWriteRepository().Add(new A() { Name = name });
        }
    }
}
