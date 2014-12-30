using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using Shared.NHibernate;

namespace UnitTests.Utils
{

    /// <summary>
    /// creates a temporal database in SQLite.
    /// </summary>
    class DomainSessionFactoryTestCreator : ISessionFactoryCreator
    {
        ////http://ayende.com/blog/3983/nhibernate-unit-testing

        private Configuration configuration;

        public DomainSessionFactoryTestCreator()
        {
            configuration = Fluently.Configure()
                 .Database(SQLiteConfiguration.Standard
                       .ConnectionString(@"data source=c:\temp\"+Guid.NewGuid().ToString()+".db")
                       .Dialect<SQLiteDialect>()
                       .Driver<SQLite20Driver>()
                   )
                   .Mappings(m => m.FluentMappings.AddFromAssemblyOf<A>()).BuildConfiguration();

        

            new NHibernate.Tool.hbm2ddl.SchemaExport(configuration).Execute(true, true, false);
        }

        public ISessionFactory GetSessionFactory()
        {                     
            return configuration.BuildSessionFactory();
        }
    }
}
