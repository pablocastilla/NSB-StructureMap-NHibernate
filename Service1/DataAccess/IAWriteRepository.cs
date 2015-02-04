using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Shared.NHibernate;

namespace Service1
{
    public interface IAWriteRepository :IWriteAbstractRepository<A>
    {
    }
}
