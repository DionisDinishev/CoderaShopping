using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoderaShopping.Domain;
using FluentNHibernate.Mapping;

namespace CoderaShopping.DataNHibernate.Mappings
{
    public class OrderMap:ClassMap<Order>
    {
        public OrderMap()
        {
            Id(x => x.Id)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable()
                .Column("Id");

            Map(x=> x.Quantity)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable()
                .Column("Quantity");

            References(x=>x.User)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable()
                .Column("UserId");

            References(x => x.Product)
                .Access.CamelCaseField(Prefix.Underscore)
                .Column("ProductId");

            HasMany(x => x.Products)
                .Inverse()
                .ForeignKeyCascadeOnDelete()
                .Access.CamelCaseField(Prefix.Underscore);
        }
    }
}
