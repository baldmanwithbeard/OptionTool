using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleSolution.Infrastructure.Repositories;

namespace SampleSolution.Infrastructure.Tests
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