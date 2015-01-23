using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Driver;
using Shared.NHibernate;

namespace Shared.NHibernate
{
    /// <summary>
    /// Creates a session factory for a model.
    ///  cfg.For<ISessionFactoryCreator>().Use<AbstractSessionFactoryCreator<A>>().Ctor<string>("connectionString").Is("Data Source=localhost:1521/xe;Persist Security Info=True;User ID=CONCEPT;Password=CONCEPT").Singleton(); 
    /// </summary>
    /// <typeparam name="T">An entity of the domain for this session</typeparam>
    public class AbstractSessionFactoryCreator<T> : ISessionFactoryCreator
    {
        private global::NHibernate.Cfg.Configuration configuration;
        private static Object lockO = new Object();
        private string connectionStringName;

        private ISessionFactory sessionFactory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionStringName">Name of the connection string in the config.</param>
        public AbstractSessionFactoryCreator(string connectionStringName)
        {
            this.connectionStringName = connectionStringName;
        }

        /// <summary>
        /// Returns the nhibernate session factory.
        /// </summary>
        /// <returns></returns>
        public ISessionFactory GetSessionFactory()
        {
            lock (lockO)
            {
                if (sessionFactory == null)
                {
                    configuration = Fluently.Configure()
                       .Database(OracleDataClientConfiguration.Oracle10
                       .ConnectionString(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString)
                       .Dialect<Oracle10gDialect>()
                       .Driver<OracleManagedDataClientDriver>()
                       )
                       .Mappings(m => m.FluentMappings.AddFromAssemblyOf<T>()).BuildConfiguration();

                    new global::NHibernate.Tool.hbm2ddl.SchemaExport(configuration).Execute(false, true, false);

                    sessionFactory = configuration.BuildSessionFactory();
                }
            }

            return sessionFactory;
        }
    }
}
