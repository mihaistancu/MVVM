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
        public void GivenNothingIsSelectedWhenContractIsSelectedThenTheFilteredDataContainsJustTheItemsThatAreSelected()
        {
            viewModel.SelectedContract = viewModel.FilteredContracts.First();

            CollectionAssert.AreEqual(new[] { viewModel.SelectedContract }, viewModel.FilteredContracts);
            CollectionAssert.AreEqual(new[] { viewModel.SelectedProvider }, viewModel.FilteredProviders);
            CollectionAssert.AreEqual(new[] { viewModel.SelectedBuyer }, viewModel.FilteredBuyers);
        }

        [TestMethod]
        public void GivenNothingIsSelectedWhenProviderIsSelectedThenTheFilteredContractsAndBuyersAreUpdated()
        {
            var providerToSelect = viewModel.FilteredProviders.First();
            var expectedFilteredContracts = viewModel.FilteredContracts.Where(c => c.Provider == providerToSelect).ToList();
            var expectedFilteredBuyers = expectedFilteredContracts.Select(c => c.Buyer).Distinct().ToList();

            viewModel.SelectedProvider = providerToSelect;
            
            CollectionAssert.AreEqual(expectedFilteredContracts, viewModel.FilteredContracts);
            CollectionAssert.AreEqual(expectedFilteredBuyers, viewModel.FilteredBuyers);
        }

        [TestMethod]
        public void GivenNothingIsSelectedWhenBuyerIsSelectedThenTheFilteredContractsAndProvidersAreUpdated()
        {
            var buyerToSelect = viewModel.FilteredBuyers.First();
            var expectedFilteredContracts = viewModel.FilteredContracts.Where(c => c.Buyer == buyerToSelect).ToList();
            var expectedFilteredProviders = expectedFilteredContracts.Select(c => c.Provider).Distinct().ToList();

            viewModel.SelectedBuyer = buyerToSelect;

            CollectionAssert.AreEqual(expectedFilteredContracts, viewModel.FilteredContracts);
            CollectionAssert.AreEqual(expectedFilteredProviders, viewModel.FilteredProviders);
        }

        [TestMethod]
        public void GivenProviderIsSelectedWhenBuyerIsSelectedThenTheFilteredContractsAreUpdated()
        {
            var providerToSelect = viewModel.FilteredProviders.First();
            var buyerToSelect = viewModel.FilteredBuyers.First();
            var expectedFilteredContracts = viewModel.FilteredContracts
                .Where(c => c.Provider == providerToSelect && c.Buyer == buyerToSelect).ToList();

            viewModel.SelectedProvider = providerToSelect;
            viewModel.SelectedBuyer = buyerToSelect;

            CollectionAssert.AreEqual(expectedFilteredContracts, viewModel.FilteredContracts);
        }

        [TestMethod]
        public void GivenProviderIsSelectedWhenBuyerIsSelectedThenTheFilteredProvidersAreUpdated()
        {
            var providerToSelect = viewModel.FilteredProviders.First();
            var buyerToSelect = viewModel.FilteredBuyers.First();
            var expectedFilteredProviders = viewModel.FilteredContracts
                .Where(c => c.Provider == providerToSelect && c.Buyer == buyerToSelect)
                .Select(c=>c.Provider).ToList();

            viewModel.SelectedProvider = providerToSelect;
            viewModel.SelectedBuyer = buyerToSelect;

            CollectionAssert.AreEqual(expectedFilteredProviders, viewModel.FilteredProviders);
        }

        [TestMethod]
        public void GivenBuyerIsSelectedWhenProviderIsSelectedThenTheFilteredContractsAreUpdated()
        {
            var providerToSelect = viewModel.FilteredProviders.First();
            var buyerToSelect = viewModel.FilteredBuyers.Skip(1).First();
            var expectedFilteredContracts = viewModel.FilteredContracts
                .Where(c => c.Provider == providerToSelect && c.Buyer == buyerToSelect).ToList();
            
            viewModel.SelectedBuyer = buyerToSelect;
            viewModel.SelectedProvider = providerToSelect;

            CollectionAssert.AreEqual(expectedFilteredContracts, viewModel.FilteredContracts);
        }
        
        [TestMethod]
        public void GivenBuyerIsSelectedWhenProviderIsSelectedThenTheFilteredBuyersAreUpdated()
        {
            var providerToSelect = viewModel.FilteredProviders.First();
            var buyerToSelect = viewModel.FilteredBuyers.Skip(1).First();
            var expectedFilteredBuyers = viewModel.FilteredContracts
                .Where(c => c.Provider == providerToSelect && c.Buyer == buyerToSelect)
                .Select(c=>c.Buyer).ToList();

            viewModel.SelectedBuyer = buyerToSelect;
            viewModel.SelectedProvider = providerToSelect;

            CollectionAssert.AreEqual(expectedFilteredBuyers, viewModel.FilteredBuyers);
        }

        [TestMethod]
        public void GivenProviderAndBuyerAreSelectedWhenContractIsSelectedThenTheFilteredDataContainsJustTheItemsThatAreSelected()
        {
            viewModel.SelectedProvider = viewModel.FilteredProviders.First();
            viewModel.SelectedBuyer = viewModel.FilteredBuyers.First();
            viewModel.SelectedContract = viewModel.FilteredContracts.First();

            CollectionAssert.AreEqual(new[] { viewModel.SelectedContract }, viewModel.FilteredContracts);
            CollectionAssert.AreEqual(new[] { viewModel.SelectedProvider }, viewModel.FilteredProviders);
            CollectionAssert.AreEqual(new[] { viewModel.SelectedBuyer }, viewModel.FilteredBuyers);
        }


        [TestMethod]
        public void GivenProviderIsSelectedWhenBuyerIsSelectedThenTheFilteredContractsAndProvidersAreUpdated()
        {
            var buyerToSelect = viewModel.FilteredBuyers.First();
            var expectedFilteredContracts = viewModel.FilteredContracts.Where(c => c.Buyer == buyerToSelect).ToList();
            var expectedFilteredProviders = expectedFilteredContracts.Select(c => c.Provider).Distinct().ToList();

            viewModel.SelectedBuyer = buyerToSelect;

            CollectionAssert.AreEqual(expectedFilteredContracts, viewModel.FilteredContracts);
            CollectionAssert.AreEqual(expectedFilteredProviders, viewModel.FilteredProviders);
        }
    }
}
