using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Shared.NHibernate;

namespace Domain.Repositories
{
    public interface IARepository : IAbstractRepository<A>
    {
        IList<A> GetAsByName(string name);
    }
}
