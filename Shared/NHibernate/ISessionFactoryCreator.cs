using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Shared.NHibernate
{
    public interface ISessionFactoryCreator
    {
        ISessionFactory GetSessionFactory();
    }
}
