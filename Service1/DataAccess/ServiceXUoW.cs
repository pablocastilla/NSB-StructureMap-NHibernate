using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Service1.WriteRepository;
using Shared.NHibernate;

namespace Service1.DataAccess
{
    public class ServiceXUoW : DomainUnitOfWork, IServiceXUoW
    {
        public ServiceXUoW(ISessionFactoryCreator sessionFactoryCreator)
            : base(sessionFactoryCreator)
        {

        }

        public IAWriteRepository GetAWriteRepository()
        {
            return new AWriteRepository(this.CurrentSession);
        }
    }
}
