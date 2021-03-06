﻿using Accounting.Models;
using Accounting.Models.Services;
using System.Collections.Generic;
using System.Linq;

namespace Accounting.ViewModels
{
    public class ContractSelectionViewModel : BindableBase
    {
        private IContractsService contractsService;
        
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

        public ContractSelectionViewModel() : this(new ContractsService())
        {
        }

        public ContractSelectionViewModel(IContractsService contractsService)
        {
            this.contractsService = contractsService;

            FilteredContracts = contractsService.GetAllContracts();
            FilteredProviders = GetFilteredProviders();
            FilteredBuyers = GetFilteredBuyers();
        }
        
        private void OnSelectedProviderChanged()
        {
            FilteredContracts = selectedBuyer == null
                ? contractsService.GetContractsBy(selectedProvider)
                : contractsService.GetContractsBy(selectedProvider, selectedBuyer);

            FilteredBuyers = GetFilteredBuyers();
        }

        private void OnSelectedBuyerChanged()
        {
            FilteredContracts = selectedProvider == null
                ? contractsService.GetContractsBy(selectedBuyer)
                : contractsService.GetContractsBy(selectedProvider, selectedBuyer);

            FilteredProviders = GetFilteredProviders();
        }

        private List<Provider> GetFilteredProviders()
        {
            return FilteredContracts.Select(c => c.Provider).Distinct().ToList();
        }

        private List<Buyer> GetFilteredBuyers()
        {
            return FilteredContracts.Select(c => c.Buyer).Distinct().ToList();
        }

        private void OnSelectedContractChanged()
        {
            SelectedProvider = selectedContract.Provider;
            SelectedBuyer = selectedContract.Buyer;

            FilteredProviders = new List<Provider> { selectedContract.Provider };
            FilteredBuyers = new List<Buyer> { selectedContract.Buyer };
            FilteredContracts = new List<Contract> { selectedContract };
        }
    }
}
