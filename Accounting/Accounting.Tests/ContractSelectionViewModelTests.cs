using Accounting.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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

        [TestMethod]
        public void WhenContractIsSelectedThenTheSelectedProviderAndSelectedBuyerAreUpdated()
        {
            var viewModel = new ContractSelectionViewModel();

            viewModel.SelectedContract = viewModel.Contracts.First();

            Assert.AreEqual(viewModel.SelectedContract.Provider, viewModel.SelectedProvider);
            Assert.AreEqual(viewModel.SelectedContract.Buyer, viewModel.SelectedBuyer);
        }
    }
}
