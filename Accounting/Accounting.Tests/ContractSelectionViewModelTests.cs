using Accounting.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Accounting.Tests
{
    [TestClass]
    public class ContractSelectionViewModelTests
    {
        ContractSelectionViewModel viewModel;

        [TestInitialize]
        public void ContractSelectionViewModelCanBeInstantiated()
        {
            viewModel = new ContractSelectionViewModel();
        }

        [TestMethod]
        public void GivenNothingIsSelectedWhenContractIsSelectedThenTheProviderAndBuyerAreAutomaticallySelected()
        {
            viewModel.SelectedContract = viewModel.FilteredContracts.First();

            Assert.AreEqual(viewModel.SelectedContract.Provider, viewModel.SelectedProvider);
            Assert.AreEqual(viewModel.SelectedContract.Buyer, viewModel.SelectedBuyer);
        }

        [TestMethod]
        public void GivenNothingIsSelectedWhenContractIsSelectedThenTheFilteredProvidersAndBuyersAndContractsContainJustTheItemsThatAreSelected()
        {
            viewModel.SelectedContract = viewModel.FilteredContracts.First();

            CollectionAssert.AreEqual(new[] { viewModel.SelectedContract }, viewModel.FilteredContracts);
            CollectionAssert.AreEqual(new[] { viewModel.SelectedProvider }, viewModel.FilteredProviders);
            CollectionAssert.AreEqual(new[] { viewModel.SelectedBuyer }, viewModel.FilteredBuyers);
        }
    }
}
