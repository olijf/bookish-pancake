using JSONToDatabaseReader;
using JSONToDatabaseReader.Datamodel;
using JSONToDatabaseReader.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace JSONToDatabaseReaderTestProject
{
    [TestClass]
    public class ReadJSONAndWriteToDbTest
    {
        [Ignore]
        [TestMethod]
        public void ReadJSONFile()
        {
            var testObject = ReadJSONAndWriteToDb.ReadFile<List<Song>>("songs.json");
            Assert.IsTrue(testObject.Count > 0);

        }
        [TestMethod]
        public void FilterList()
        {
            var testData = @"[{
    		""Id"": 760,
            ""Name"": ""\""Weird Al\"" Yankovic""
              }, {
    		""Id"": 3,
    		""Name"": "".38 Special""
            	}, {
    		""Id"": 1,
    		""Name"": ""3 Doors Down""
         	}]";

            var testObject = JSONToDatabaseReader.JSON.Serialization.Deserialize<List<Artist>>(testData);
            var resultingList = ReadJSONAndWriteToDb.FilterEnumerable(testObject, x => x.Name.Contains("3"));
            System.Console.WriteLine("read list contains " + testObject.Count + " items");
            System.Console.WriteLine("filtered contains " + resultingList.Count() + " items");
            Assert.IsTrue(testObject.Count != resultingList.Count());
        }

        [TestMethod]
        public void WriteListToDb()
        {
            var repository = new NHibernateRepository<Artist>();
            NHibernateHelper.CreateDatabaseIfNeeded();
            for (int i = 0; i < 3; i++)
            {
                var testObject = new Artist
                {
                    Id = i,
                    Name = "TestBoodschap"
                };
                repository.Save(testObject);
            }
        }
    }
}
