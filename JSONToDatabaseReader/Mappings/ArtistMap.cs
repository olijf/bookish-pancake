using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace JSONToDatabaseReader.Mappings
{
    public class ArtistMap : ClassMapping<Datamodel.Artist>
    {
        public ArtistMap()
        {
            Table("artists");
            Id(x => x.Id, m => m.Generator(Generators.Assigned));
            Property(x => x.Name);
        }
    }
}
