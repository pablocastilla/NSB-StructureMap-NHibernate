using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.NHibernate
{
    public interface IWriteAbstractRepository<TEntity> where TEntity : class
    {
        void Add(TEntity e);

        void Update(TEntity e);

        void Delete(TEntity e);
    }
}
