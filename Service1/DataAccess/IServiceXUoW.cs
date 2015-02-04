using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Shared.NHibernate;

namespace Service1.DataAccess
{
    public interface IServiceXUoW : IDomainUnitOfWork
    {
        IAWriteRepository GetAWriteRepository();
    }
}
