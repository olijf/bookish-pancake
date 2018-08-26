using JSONDbAPI.Controllers;
using JSONToDatabaseReader.Datamodel;
using JSONToDatabaseReader.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace JSONToDatabaseReaderTestProject
{
    [TestClass]
    public class ApiUnittest
    {
        private IRepository<Song> _testRepo { get; set; }
        [TestInitialize]
        public void SetupDummyRepo()
        {
            _testRepo = new TestRepository<Song>();
            var r = new System.Random();
            for (int i = 0; i < 20; i++)
            {
                _testRepo.Save(new Song() { Id = i, Artist = "Hans" + i, Year = r.Next(1900, 2000) });
            }
        }
        [TestMethod]
        public void ArtistGet()
        {
            var TestSubject = new ArtistsController(_testRepo);
            var Result = TestSubject.Get();
            Assert.IsTrue(Result.ToList().Count > 19);
        }
        [Ignore]
        [TestMethod]
        public void ArtistFilter()
        {
            var testSubject = new ArtistsController(_testRepo);
            var result = testSubject.Get("Hans2");
            Assert.IsTrue(result != null);
            var resultList = result.ToList();
            var resultItem = resultList.FirstOrDefault();
            Assert.IsTrue(resultItem == "Hans2");
        }
        [TestMethod]
        public void SongsGet()
        {
            var testSubject = new SongsController(_testRepo);
            var result = testSubject.Get();
            Assert.IsTrue(result.Value.ToList().Count > 19);
        }
        [TestMethod]
        public void SongsDelete()
        {
            var testSubject = new SongsController(_testRepo);
            var testObject = _testRepo.Get(0);
            testSubject.Delete(testObject.Id);
            Assert.IsTrue(_testRepo.GetAll().Count < 20);
        }
        [TestMethod]
        public void SongsPost()
        {
            var testSubject = new SongsController(_testRepo);
            var testObject = new Song() { Id = 20, Artist = "TestArtist" };
            testSubject.Post(testObject);
            Assert.IsTrue(_testRepo.GetAll().Count > 20);
        }
        [TestMethod]
        public void SongsPut()
        {
            var testSubject = new SongsController(_testRepo);
            var newObject = new Song() { Id = 1, Artist = "TestArtist" };
            testSubject.Put(1, newObject);
            Assert.IsTrue(_testRepo.Get(1).Artist == "TestArtist");
        }
        [TestMethod]
        public void SongsGetById()
        {
            var testSubject = new SongsController(_testRepo);
            Assert.IsTrue(testSubject.Get(1).Value.Artist == "Hans1");
        }
        [TestMethod]
        public void SongsGetByIdNotFound()
        {
            var testSubject = new SongsController(_testRepo);
            Assert.IsTrue(testSubject.Get(300).Result.GetType() == new Microsoft.AspNetCore.Mvc.NotFoundResult().GetType());
        }
        [TestMethod]
        public void SongsFilter()
        {
            var testSubject = new SongsController(_testRepo);
            //var result = testSubject.Get("Hans2");
            var fact = _testRepo.GetQueryable().Where(x => x.Artist == "Hans2").ToList();
            /*Assert.IsTrue(result != null);
            var resultList = result.Value;
            var resultItem = resultList.FirstOrDefault();
            Assert.IsTrue(resultItem.Artist == "Hans2");*/
        }
    }
}
