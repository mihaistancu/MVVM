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
        public void GivenNothingIsSelectedWhenContractIsSelectedThenTheProviderAndBuyerAreAutomaticallySelected()
        {
            var viewModel = new ContractSelectionViewModel();

            viewModel.SelectedContract = viewModel.FilteredContracts.First();

            Assert.AreEqual(viewModel.SelectedContract.Provider, viewModel.SelectedProvider);
            Assert.AreEqual(viewModel.SelectedContract.Buyer, viewModel.SelectedBuyer);
        }

        [TestMethod]
        public void GivenNothingIsSelectedWhenContractIsSelectedThenTheFilteredProvidersAndBuyersAndContractsContainJustTheItemsThatAreSelected()
        {
            var viewModel = new ContractSelectionViewModel();

            viewModel.SelectedContract = viewModel.FilteredContracts.First();

            CollectionAssert.AreEqual(new[] { viewModel.SelectedContract }, viewModel.FilteredContracts);
            CollectionAssert.AreEqual(new[] { viewModel.SelectedProvider }, viewModel.FilteredProviders);
            CollectionAssert.AreEqual(new[] { viewModel.SelectedBuyer }, viewModel.FilteredBuyers);
        }
    }
}
