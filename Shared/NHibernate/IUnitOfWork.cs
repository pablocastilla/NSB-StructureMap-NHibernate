using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Shared.NHibernate
{
    public interface IUnitOfWork : IDisposable
    {
        ISession CurrentSession { get; }

        void Commit();
        
    }
}
