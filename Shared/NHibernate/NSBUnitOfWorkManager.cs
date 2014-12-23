using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus.UnitOfWork;
using Shared.NHibernate;

namespace Shared
{
    public class NSBUnitOfWorkManager : IManageUnitsOfWork 
    {
        public IUnitOfWork UoW { get; set; }

        public void Begin()
        {
           
            
        }

        public void End(Exception ex = null)
        {
            UoW.Commit();           
        }
    }
}
