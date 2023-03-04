using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptionTool.Domain.Entities;
using OptionTool.Infrastructure.Repositories;

namespace OptionTool.Infrastructure.Tests.Repositories
{
    [TestClass()]
    public class OptionInformationRepositoryTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var entityCollection = new OptionInformationRepository().GetAll().ToList();
            Assert.IsNotNull(entityCollection);
            Assert.IsTrue(entityCollection.Count > 0);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var optionTreeProperty = new OptionTree { Id = 0, Category1 = "Root", Category2 = "Trunk", Category3 = "Branch", Category4 = "Leaf" };
            var expectedOptionInformation = new OptionInformation { Id = 0, OptionId = "123456", OptionSequence = "0000", Label = "Boolean Option", TranslationId = 420, OptionValueType = 0, ValueLookupObject = null, ValueEnumGroup = null, OptionTree = optionTreeProperty };
            var loadedOptionInformation = new OptionInformationRepository().GetById(0);
            Assert.AreEqual(expectedOptionInformation.Id, loadedOptionInformation.Id);
            Assert.AreEqual(expectedOptionInformation.OptionId, loadedOptionInformation.OptionId);
            Assert.AreEqual(expectedOptionInformation.OptionSequence, loadedOptionInformation.OptionSequence);
            Assert.AreEqual(expectedOptionInformation.Label, loadedOptionInformation.Label);
            Assert.AreEqual(expectedOptionInformation.TranslationId, loadedOptionInformation.TranslationId);
            Assert.AreEqual(expectedOptionInformation.OptionValueType, loadedOptionInformation.OptionValueType);
            Assert.AreEqual(null, loadedOptionInformation.ValueLookupObject?.LookupObjectName);
            Assert.AreEqual(null, loadedOptionInformation.ValueEnumGroup);
            Assert.AreEqual(expectedOptionInformation.OptionTree.Id, loadedOptionInformation.OptionTree.Id);
            Assert.AreEqual(expectedOptionInformation.OptionTree.Category1, loadedOptionInformation.OptionTree.Category1);
            Assert.AreEqual(expectedOptionInformation.OptionTree.Category2, loadedOptionInformation.OptionTree.Category2);
            Assert.AreEqual(expectedOptionInformation.OptionTree.Category3, loadedOptionInformation.OptionTree.Category3);
            Assert.AreEqual(expectedOptionInformation.OptionTree.Category4, loadedOptionInformation.OptionTree.Category4);
        }

        [TestMethod()]
        public void InsertAndDeleteTest()
        {
            var optionTreeProperty = new OptionTree { Id = 0, Category1 = "Root", Category2 = "Trunk", Category3 = "Branch", Category4 = "Leaf" };
            var entity = new OptionInformation { Id = 9999, OptionId = "123321", OptionSequence = "0000", Label = "Test Label", TranslationId = 64, OptionValueType = 0, ValueLookupObject = null, ValueEnumGroup = null, OptionTree = optionTreeProperty };
            var repository = new OptionInformationRepository();
            Assert.AreEqual("Created 1 record successfully", repository.Insert(entity));
            Assert.AreEqual("Deleted 1 record successfully", repository.Delete(entity));
        }
    }
}