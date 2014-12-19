using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

[assembly: InternalsVisibleTo("UnitTests")]
namespace Shared.NHibernate
{
    
    class UnitOfWork : IUnitOfWork
    {
        public Guid id { get; set; }

        public UnitOfWork()
        {
            id = Guid.NewGuid();
        }

        public ISession CurrentSession
        {
            get { throw new NotImplementedException(); }
        }

        public void Commit()
        {
          //  throw new NotImplementedException();
        }

        public void Dispose()
        {
          //  throw new NotImplementedException();
        }
    }
}
