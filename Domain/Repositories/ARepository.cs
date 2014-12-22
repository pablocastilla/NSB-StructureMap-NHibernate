using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using NHibernate;
using Shared.NHibernate;

namespace Domain.Repositories
{
    class ARepository : AbstractRepository<A>,IARepository
    {
       

        public ARepository(ISession session)
        {
            this.session = session;
        }

        public IList<A> GetAsByName(string name)
        {
            //throw new NotImplementedException();

            return null;
        }
    }
}
