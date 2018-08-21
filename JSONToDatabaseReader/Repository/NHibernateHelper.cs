using System.Collections.Generic;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using JSONToDatabaseReader.Mappings;

namespace JSONToDatabaseReader.Repository
{
    //TODO: https://github.com/FluentNHibernate/fluent-nhibernate/wiki/Getting-started
    public static class NHibernateHelper
    {
        private static Configuration _configuration;
        private static ISession _session;

        public static ISession Session
        {
            get
            {
                if (_session == null)
                {
                    //Open and return the nhibernate session
                    ISessionFactory sessionFactory = Configuration.BuildSessionFactory();
                    _session = sessionFactory.OpenSession();
                }
                return _session;
            }
        }

        public static Configuration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    //Create the nhibernate configuration
                    _configuration = CreateConfiguration();
                }
                return _configuration;
            }
        }

        private static Configuration CreateConfiguration()
        {
            var configuration = new Configuration();
            //Loads properties from hibernate.cfg.xml
            //configuration.Configure();
            //configuration.SetProperty("connection.driver_class", "NHibernate.Driver.SQLite20Driver");
            configuration.SetProperty("connection.connection_string", "Data Source=test.db;Version=3;New=True");
            configuration.SetProperty("dialect", "NHibernate.Dialect.SQLiteDialect");

            //Loads nhibernate mappings 
            configuration.AddDeserializedMapping(CreateMapping(), null);
            return configuration;
        }

        private static HbmMapping CreateMapping()
        {
            var mapper = new ModelMapper();
            //Add the person mapping to the model mapper
            mapper.AddMappings(new List<System.Type> { typeof(ArtistMap), typeof(SongMap)});
            //Create and return a HbmMapping of the model mapping in code
            return mapper.CompileMappingForAllExplicitlyAddedEntities();
        }


        public static void CreateDatabaseIfNeeded()
        {
            var schemaUpdate = new SchemaUpdate(NHibernateHelper.Configuration);
            schemaUpdate.Execute(false, true);
        }
    }
}