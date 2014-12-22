using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using FluentNHibernate.Mapping;

namespace Domain.Mappings
{
    public  class AMap : ClassMap<A>
    {
        public AMap()
        {
            Table("A");
            LazyLoad();
            Id(x => x.ID,"ID").GeneratedBy.Sequence("A_SEQ");
            Map(x => x.Name).Column("NAME");
           
        }
    }
}
