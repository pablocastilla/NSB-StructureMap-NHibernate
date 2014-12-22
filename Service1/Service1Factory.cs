using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace Service1
{
    public class Service1Factory : IService1Factory
    {
        private IContainer container;

        public Service1Factory(IContainer container)
        {
            this.container = container;
        }


        public IService1 CreateService(string vendorName)
        {
            if (vendorName.ToUpper() == "VENDORX")
                return container.GetInstance<IService1>("VENDORX");

            throw new ArgumentOutOfRangeException("Vendor doesn't exist!!!");
        }
    }
}
