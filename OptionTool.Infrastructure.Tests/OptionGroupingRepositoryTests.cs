using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptionTool.Infrastructure.Repositories;

namespace OptionTool.Infrastructure.Tests
{
    [TestClass]
    public class OptionGroupingRepositoryTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var optionGroupings = new OptionTreeRepository().GetAll();
        }
    }
}