using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptionTool.Domain.Entities;
using OptionTool.Infrastructure.Repositories;

namespace OptionTool.Infrastructure.Tests.Repositories
{
    [TestClass()]
    public class ValueEnumItemRepositoryTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var entityCollection = new ValueEnumItemRepository().GetAll()?.ToList();
            Assert.IsNotNull(entityCollection);
            Assert.IsTrue(entityCollection.Count > 0);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var entity = new ValueEnumItemRepository().GetById(0);
            Assert.IsNotNull(entity);
            Assert.AreEqual(0, entity.Id);
            Assert.AreEqual("ExampleEnumItem", entity.EnumItem);
        }

        [TestMethod()]
        public void InsertAndDeleteTest()
        {
            var entity = new ValueEnumItem { Id = 9999, EnumItem = "TestEnumItem" };
            var repository = new ValueEnumItemRepository();
            Assert.AreEqual("Created 1 record successfully", repository.Insert(entity));
            Assert.AreEqual("Deleted 1 record successfully", repository.Delete(entity));
        }
    }
}