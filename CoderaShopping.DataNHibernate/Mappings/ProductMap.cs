using CoderaShopping.Domain;
using FluentNHibernate.Mapping;

namespace CoderaShopping.DataNHibernate.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable()
                .Column("Id");

            Map(x => x.Name)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable()
                .Column("Name");

            Map(x => x.Description)
                .Access.CamelCaseField(Prefix.Underscore)
                .Nullable()
                .Column("Description");

            References(x => x.Category)
                .Access.CamelCaseField(Prefix.Underscore)
                .Column("CategoryId");

            HasMany(x => x.Orders)
                .Inverse()
                .ForeignKeyCascadeOnDelete()
                .Access.CamelCaseField(Prefix.Underscore);
        }
    }
}
