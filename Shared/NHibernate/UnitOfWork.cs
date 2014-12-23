using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;

[assembly: InternalsVisibleTo("UnitTests")]
namespace Shared.NHibernate
{
    
    public abstract class UnitOfWork : IUnitOfWork
    {
        public Guid id { get; set; }
                       
        private ISession session;
        
      
        public UnitOfWork(ISessionFactoryCreator sessionFactoryCreator)
        {
            id = Guid.NewGuid();

            //creates the session factory
            sessionFactoryCreator.GetSessionFactory();
            session = sessionFactoryCreator.GetSessionFactory().OpenSession();

            //begins the transaction that will be used in the handler
            session.BeginTransaction();

        }

     
        public ISession CurrentSession
        {
            get { return session; }

       }

        public void Commit()
        {
            session.Transaction.Commit();
        }

        public void Dispose()
        {
            if (session.Transaction != null)
            {
                session.Transaction.Dispose();
            }

            if (session != null)
            {
                session.Dispose();
            }
          
        }
    }
}
