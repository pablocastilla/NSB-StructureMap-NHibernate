using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Shared.NHibernate
{
    public abstract class AbstractRepository <TEntity> : IAbstractRepository <TEntity> where TEntity:class
    {
        protected  ISession session;
        public void Add(TEntity e)
        {
            session.Save(e);
        }

        public void Update(TEntity e)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity e)
        {
            throw new NotImplementedException();
        }

        public void GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void GetByIdBlocking(object id)
        {
            throw new NotImplementedException();
        }
    }
}
