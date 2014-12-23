using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using FluentNHibernate.Mapping;
using Shared;

namespace Domain.Mappings
{
    public  class AMap : ClassMap<A>
    {
        public AMap()
        {
            Table("A");
            LazyLoad();

            if (!UnitTestDetector.IsInUnitTest)
            {
                Id(x => x.ID, "ID").GeneratedBy.Sequence("A_SEQ");
            }
            else
            {
                Id(x => x.ID, "ID").GeneratedBy.Native();
            }

            Map(x => x.Name).Column("NAME");
           
        }
    }
}
