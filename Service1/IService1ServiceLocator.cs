using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service1
{
    /// <summary>
    /// class that returns a service by its vendor
    /// </summary>
    public interface IService1ServiceLocator
    {
        IService1 CreateService(string vendorName);
    }
}
