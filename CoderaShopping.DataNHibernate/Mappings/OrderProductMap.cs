using CoderaShopping.Domain;
using FluentNHibernate.Mapping;

namespace CoderaShopping.DataNHibernate.Mappings
{
    public class OrderProductMap:ClassMap<OrderProduct>
    {
        public OrderProductMap()
        {
            Id(x=>x.Id)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable()
                .Column("Id");
            Map(x=>x.Quantity)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable()
                .Column("Quantity");

            HasMany(x=>x.Products)
                .KeyColumn("ProductId")
                .Inverse()
                .ForeignKeyCascadeOnDelete()
                .Access.CamelCaseField(Prefix.Underscore);

            References(x=>x.Product)
                .Access.CamelCaseField(Prefix.Underscore)
                .Column("ProductId");

            References(x => x.Order)
                .Access.CamelCaseField(Prefix.Underscore)
                .Column("OrderId");
        }
    }
}
