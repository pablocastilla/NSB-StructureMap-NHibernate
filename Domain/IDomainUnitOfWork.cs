using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories;
using Shared.NHibernate;

namespace Domain
{
    public interface IDomainUnitOfWork : IUnitOfWork
    {
        IARepository GetARepository();
    }
}
