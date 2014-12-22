using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Driver;
using Shared.NHibernate;

namespace Domain
{
    class DomainUnitOfWork : UnitOfWork, IDomainUnitOfWork
    {
     

        public DomainUnitOfWork(ISessionFactoryCreator sessionFactoryCreator)
            : base(sessionFactoryCreator)
        {

        }


        IARepository IDomainUnitOfWork.GetARepository()
        {
            return new ARepository(this.CurrentSession);
        }
               
    }
}
