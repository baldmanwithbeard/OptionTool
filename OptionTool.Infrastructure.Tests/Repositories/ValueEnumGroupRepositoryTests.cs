using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptionTool.Domain.Entities;
using OptionTool.Infrastructure.Repositories;

namespace OptionTool.Infrastructure.Tests.Repositories
{
    [TestClass()]
    public class ValueEnumGroupRepositoryTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var entityCollection = new ValueEnumGroupRepository().GetAll()?.ToList();
            Assert.IsNotNull(entityCollection);
            Assert.IsTrue(entityCollection.Count > 0);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var entity = new ValueEnumGroupRepository().GetById(0);
            Assert.IsNotNull(entity);
            Assert.AreEqual(0, entity.Id);
            Assert.AreEqual("ExampleEnumItem", entity.EnumItems[0].EnumItem);
            Assert.AreEqual("AnotherExampleEnumItem", entity.EnumItems[1].EnumItem);
        }

        [TestMethod()]
        public void InsertAndDeleteTest()
        {
            var entity = new ValueEnumGroup { Id = 9999 }; //enumItems null
            var repository = new ValueEnumGroupRepository();
            Assert.AreEqual("Created 1 record successfully", repository.Insert(entity));
            Assert.AreEqual("Deleted 1 record successfully", repository.Delete(entity));
        }
    }
}