using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Domain;
using NServiceBus;
using Service1.DataAccess;
using StructureMap;

[assembly: InternalsVisibleTo("UnitTests")]
namespace Service1
{
    public class Service1ServiceLocator : IService1ServiceLocator
    {
        private IBus bus;

        private IServiceXUoW uow;

        public Service1ServiceLocator(IServiceXUoW uow, IBus bus)
        {
            this.bus = bus;
            this.uow = uow;
        }


        public IService1 CreateService(string vendorName)
        {
            if (vendorName.ToUpper() == "VENDORX")
                return new VendorXService1(uow, bus);

            throw new ArgumentOutOfRangeException("Vendor doesn't exist!!!");
        }
    }
}
