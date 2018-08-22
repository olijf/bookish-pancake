using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace JSONToDatabaseReader.Mappings
{
    public class SongMap : ClassMapping<Datamodel.Song>
    {
        public SongMap()
        {
            Table("songs");
            Id(x => x.Id, m => m.Generator(Generators.Assigned));
            Property(x => x.Artist);
            Property(x => x.Album);
            Property(x => x.Name);
            Property(x => x.Shortname);
            Property(x => x.Year);
            Property(x => x.Genre);
            Property(x => x.Bpm);
            Property(x => x.Duration);
            Property(x => x.SpotifyId);
        }
    }
}
