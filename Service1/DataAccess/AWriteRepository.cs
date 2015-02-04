using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using NHibernate;
using Shared.NHibernate;

namespace Service1.WriteRepository
{
    public class AWriteRepository : WriteAbstractRepository<A>, IAWriteRepository
    {
        public AWriteRepository(ISession session)
        {
            this.session = session;
        }
    }
}
