using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Dialect;
using NHibernate.Driver;
using Shared.NHibernate;

namespace Domain
{
    class DomainSessionFactoryCreator : ISessionFactoryCreator
    {
        public NHibernate.ISessionFactory CreateSessionFactory()
        {
            var configuration = Fluently.Configure()
                     .Database(OracleDataClientConfiguration.Oracle10
                         .ConnectionString(ConfigurationManager.ConnectionStrings["CONCEPT"].ConnectionString)
                         .Dialect<Oracle10gDialect>()
                         .Driver<OracleManagedDataClientDriver>()
                     )
                     .Mappings(m => m.FluentMappings.AddFromAssemblyOf<A>()).BuildConfiguration();

            new NHibernate.Tool.hbm2ddl.SchemaExport(configuration).Execute(false, true, false);

            return configuration.BuildSessionFactory();
        }
    }
}
