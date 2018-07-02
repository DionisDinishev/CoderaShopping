using CoderaShopping.Domain;
using FluentNHibernate.Mapping;

namespace CoderaShopping.DataNHibernate.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable()
                .Column("Id");

            Map(x => x.Name)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable()
                .Column("Name");

            Map(x=>x.Email)
                .Access.CamelCaseField(Prefix.Underscore)
                .Nullable()
                .Column("Email");

            Map(x=>x.Phone)
                .Access.CamelCaseField(Prefix.Underscore)
                .Nullable()
                .Column("Phone");

            Map(x=>x.UserType).CustomType<GenericEnumMapper<UserType>>()
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable()
                .Column("UserType");

            HasMany(x=>x.Orders)
                .Inverse()
                .Cascade.AllDeleteOrphan()
                .Access.CamelCaseField(Prefix.Underscore);

        }
    }
}
