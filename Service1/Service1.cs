using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.NHibernate;

namespace Service1
{
    public class Service1 : IService1
    {
        public IUnitOfWork UoW { get; set; }

        public void DoSomething()
        {
           // throw new NotImplementedException();
        }
    }
}
