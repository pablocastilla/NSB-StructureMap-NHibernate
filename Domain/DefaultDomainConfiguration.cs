using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Shared;
using Shared.NHibernate;
using StructureMap;
using StructureMap.Pipeline;

namespace Domain
{
    public static class DefaultDomainConfiguration
    {
        public static void SetDefaultDomainConfiguration(this IContainer container)
        {
            
            container.Configure(
                cfg =>
                {
                    cfg.For<IDomainUnitOfWork>().Use<DomainUnitOfWork>();
                    cfg.Forward<IDomainUnitOfWork,IUnitOfWork>();
                    cfg.Policies.FillAllPropertiesOfType<IUnitOfWork>();
                    cfg.For<ISessionFactoryCreator>().Use<AbstractSessionFactoryCreator<A>>().Ctor<string>("connectionStringName").Is("CONCEPT").Singleton(); 

                                             
                }
                );

         
        }
    }
}
