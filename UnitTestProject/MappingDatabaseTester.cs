using JSONToDatabaseReader.Datamodel;
using JSONToDatabaseReader.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace JSONToDatabaseReaderTestProject
{
    [TestClass]
    public class MappingDatabaseTester
    {
        [TestMethod]
        public void MappingTest()
        {
            var testObject = new Artist
            {
                Id = 123,
                Name = "TestBoodschap"
            };
            var repository = new NHibernateRepository<Artist>();
            NHibernateHelper.CreateDatabaseIfNeeded();
            repository.Save(testObject);
            var result = repository.Get(123);
            Assert.IsTrue(testObject == result);
            Assert.IsTrue(repository.GetAll().Count > 0);

        }
    }
}
