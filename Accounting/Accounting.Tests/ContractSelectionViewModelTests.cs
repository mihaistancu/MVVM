using Accounting.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Accounting.Tests
{
    [TestClass]
    public class ContractSelectionViewModelTests
    {
        [TestMethod]
        public void ContractSelectionViewModelCanBeInstantiated()
        {
            var viewModel = new ContractSelectionViewModel();
            Assert.IsNotNull(viewModel);
        }
    }
}
