using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptionTool.Domain.Entities;
using OptionTool.Infrastructure.Repositories;

namespace OptionTool.Infrastructure.Tests.Repositories
{
    [TestClass()]
    public class OptionTreeRepositoryTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var entityCollection = new OptionTreeRepository().GetAll()?.ToList();
            Assert.IsNotNull(entityCollection);
            Assert.IsTrue(entityCollection.Count > 0);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var entity = new OptionTreeRepository().GetById(0);
            Assert.IsNotNull(entity);
            Assert.AreEqual(0, entity.Id);
            Assert.AreEqual("Root", entity.Category1);
            Assert.AreEqual("Trunk", entity.Category2);
            Assert.AreEqual("Branch", entity.Category3);
            Assert.AreEqual("Leaf", entity.Category4);
        }

        [TestMethod()]
        public void InsertAndDeleteTest()
        {
            var entity = new OptionTree { Id = 9999, Category1 = "Test Root Category", Category2 = "TestCategory2", Category3 = "" };
            var repository = new OptionTreeRepository();
            Assert.AreEqual("Created 1 record successfully", repository.Insert(entity));
            Assert.AreEqual("Deleted 1 record successfully", repository.Delete(entity));
        }
    }
}