using CoderaShopping.Domain;
using FluentNHibernate.Mapping;

namespace CoderaShopping.DataNHibernate.Mappings
{
    public class CategoryMap:ClassMap<Category>
    {

        public CategoryMap()
        {
            Id(x => x.Id)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable()
                .Column("Id");

            Map(x => x.Name)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable()
                .Column("Name");

            Map(x => x.Status)
                .Access.CamelCaseField(Prefix.Underscore)
                .Nullable()
                .Column("Status");

            Map(x => x.IsDefault)
                .Access.CamelCaseField(Prefix.Underscore)
                .Nullable()
                .Column("IsDefault");
            
            HasMany(x => x.Products)
                .Inverse()
                .ForeignKeyCascadeOnDelete()
                .Cascade.AllDeleteOrphan()
                .Access.CamelCaseField(Prefix.Underscore);

        }
    }
}
