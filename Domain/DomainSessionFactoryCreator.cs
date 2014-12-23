using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Driver;
using Shared.NHibernate;

namespace Domain
{
    class DomainSessionFactoryCreator : ISessionFactoryCreator
    {
        private NHibernate.Cfg.Configuration configuration;

        private ISessionFactory sessionFactory;
 
        public DomainSessionFactoryCreator()
        {
                configuration = Fluently.Configure()
                .Database(OracleDataClientConfiguration.Oracle10
                .ConnectionString(ConfigurationManager.ConnectionStrings["CONCEPT"].ConnectionString)
                .Dialect<Oracle10gDialect>()
                .Driver<OracleManagedDataClientDriver>()
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<A>()).BuildConfiguration();

                new NHibernate.Tool.hbm2ddl.SchemaExport(configuration).Execute(false, true, false);

                sessionFactory = configuration.BuildSessionFactory();
        }

        public NHibernate.ISessionFactory GetSessionFactory()
        {
            return sessionFactory;
        }
    }
}
