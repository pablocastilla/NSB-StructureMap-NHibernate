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
    public  class BMap : ClassMap<B>
    {
        public BMap()
        {
            Table("B");
            //Schema("TITANIUMSTG");
            LazyLoad();
            
            if (!UnitTestDetector.IsInUnitTest)
            {
                Id(x => x.ID, "ID").GeneratedBy.Sequence("B_SEQ");
            }
            else
            {
                Id(x => x.ID, "ID").GeneratedBy.Native();
            }

            Map(x => x.Address).Column("ADDRESS");
           
        }
    }
}
