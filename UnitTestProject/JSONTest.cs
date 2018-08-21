using JSONToDatabaseReader.Datamodel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class JSONTest
    {
        [TestMethod]
        public void DeserializeSongTest()
        {
            var testData = @"{
		""Id"": 190,
        ""Name"": ""(Don't Fear) The Reaper"",
		""Year"": 1975,
		""Artist"": ""Blue Öyster Cult"",
		""Shortname"": ""dontfearthereaper"",
		""Bpm"": 141,
		""Duration"": 322822,
		""Genre"": ""Classic Rock"",
		""SpotifyId"": ""5QTxFnGygVM4jFQiBovmRo"",
		""Album"": ""Agents of Fortune""}";

            Song result = JSONToDatabaseReader.JSON.Serialization.Deserialize<Song>(testData);

            Assert.IsTrue(result.Id > 0 && result.Name != string.Empty);

        }

        [TestMethod]
        public void DeserializeArtistTest()
        {
            var testData = @"{""Id"": 760, ""Name"": ""Weird Al Yankovic""}";

            var result = JSONToDatabaseReader.JSON.Serialization.Deserialize<Artist>(testData);

            Assert.IsTrue(result.Id > 0 && result.Name != string.Empty);

        }

        [TestMethod]
        public void DeserializeArtistListTest()
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

            var result = JSONToDatabaseReader.JSON.Serialization.Deserialize<List<Artist>>(testData);

            Assert.IsTrue(result.Count == 3 && result.FirstOrDefault().Name != string.Empty);

        }

        [TestMethod]
        public void SerializeArtistTest()
        {
            var testData = new Artist
            {
                Id = 381,
                Name = "Hans"
            };

            var result = JSONToDatabaseReader.JSON.Serialization.Serialize(testData);

            Assert.IsTrue(result != string.Empty);
            Assert.IsTrue(result.Contains("Hans"));
        }
    }
}
