using Accounting.Models;
using Accounting.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Accounting.ViewModels
{
    public class ContractSelectionViewModel : BindableBase
    {
        private ContractsService contractsService;
        
        private List<Provider> filteredProviders;

        public List<Provider> FilteredProviders
        {
            get { return filteredProviders; }
            set { SetProperty(ref filteredProviders, value); }
        }

        private Provider selectedProvider;

        public Provider SelectedProvider
        {
            get { return selectedProvider; }
            set { SetProperty(ref selectedProvider, value, OnSelectedProviderChanged); }
        }

        private List<Buyer> filteredBuyers;

        public List<Buyer> FilteredBuyers
        {
            get { return filteredBuyers; }
            set { SetProperty(ref filteredBuyers, value); }
        }

        private Buyer selectedBuyer;

        public Buyer SelectedBuyer
        {
            get { return selectedBuyer; }
            set { SetProperty(ref selectedBuyer, value, OnSelectedBuyerChanged); }
        }

        private List<Contract> filteredContracts;

        public List<Contract> FilteredContracts
        {
            get { return filteredContracts; }
            set { SetProperty(ref filteredContracts, value); }
        }

        private Contract selectedContract;

        public Contract SelectedContract
        {
            get { return selectedContract; }
            set { SetProperty(ref selectedContract, value, OnSelectedContractChanged); }
        }

        private void OnSelectedProviderChanged()
        {
            FilteredContracts = selectedBuyer == null
                ? contractsService.GetContractsByProvider(selectedProvider)
                : contractsService.GetContractsByProviderAndBuyer(selectedProvider, selectedBuyer);

            FilteredBuyers = FilteredContracts.Select(c => c.Buyer).Distinct().ToList();
        }

        private void OnSelectedBuyerChanged()
        {
            FilteredContracts = selectedProvider == null
                ? contractsService.GetContractsByBuyer(selectedBuyer)
                : contractsService.GetContractsByProviderAndBuyer(selectedProvider, selectedBuyer);

            FilteredProviders = FilteredContracts.Select(c => c.Provider).Distinct().ToList();
        }

        private void OnSelectedContractChanged()
        {
            SelectedProvider = selectedContract.Provider;
            SelectedBuyer = selectedContract.Buyer;

            FilteredProviders = new List<Provider> { selectedContract.Provider };
            FilteredBuyers = new List<Buyer> { selectedContract.Buyer };
            FilteredContracts = new List<Contract> { selectedContract };
        }

        public ContractSelectionViewModel()
        {
            contractsService = new ContractsService();

            FilteredContracts = contractsService.GetAllContracts();
            FilteredProviders = FilteredContracts.Select(c=>c.Provider).Distinct().ToList();
            FilteredBuyers = FilteredContracts.Select(c => c.Buyer).Distinct().ToList();
        }
    }
}
