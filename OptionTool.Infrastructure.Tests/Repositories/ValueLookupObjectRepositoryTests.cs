using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptionTool.Domain.Entities;
using OptionTool.Infrastructure.Repositories;

namespace OptionTool.Infrastructure.Tests.Repositories
{
    [TestClass()]
    public class ValueLookupObjectRepositoryTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var entityCollection = new ValueLookupObjectRepository().GetAll()?.ToList();
            Assert.IsNotNull(entityCollection);
            Assert.IsTrue(entityCollection.Count > 0);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var entity = new ValueLookupObjectRepository().GetById(0);
            Assert.IsNotNull(entity);
            Assert.AreEqual(0, entity.Id);
            Assert.AreEqual("ExampleLookupObject", entity.LookupObjectName);
        }

        [TestMethod()]
        public void InsertAndDeleteTest()
        {
            var entity = new ValueLookupObject { Id = 9999, LookupObjectName = "TestLookupObject" };
            var repository = new ValueLookupObjectRepository();
            Assert.AreEqual("Created 1 record successfully", repository.Insert(entity));
            Assert.AreEqual("Deleted 1 record successfully", repository.Delete(entity));
        }
    }
}