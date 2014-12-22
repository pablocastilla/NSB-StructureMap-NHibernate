using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service1
{
    public interface IService1Factory
    {
        IService1 CreateService(string vendorName);
    }
}
