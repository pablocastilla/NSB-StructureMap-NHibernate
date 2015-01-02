using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Domain;
using NServiceBus;
using StructureMap;

[assembly: InternalsVisibleTo("UnitTests")]
namespace Service1
{
    public class Service1ServiceLocator : IService1ServiceLocator
    {
        private IBus bus;

        private IDomainUnitOfWork domainUoW;
       
        public Service1ServiceLocator(IDomainUnitOfWork UoW, IBus bus)
        {
            this.bus = bus;
            this.domainUoW = UoW;
        }


        public IService1 CreateService(string vendorName)
        {
            if (vendorName.ToUpper() == "VENDORX")
                return new VendorXService1(domainUoW,bus);

            throw new ArgumentOutOfRangeException("Vendor doesn't exist!!!");
        }
    }
}
