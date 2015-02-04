using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.NHibernate
{
    public interface IReadAbstractRepository<TEntity> where TEntity:class
    {     

        void GetById(object id);

        void GetByIdBlocking(object id);
    }
}
