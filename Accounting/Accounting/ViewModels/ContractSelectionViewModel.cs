using Accounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Accounting.ViewModels
{
    public class ContractSelectionViewModel : BindableBase
    {
        private List<Provider> allProviders;
        private List<Buyer> allBuyers;
        private List<Contract> allContracts;

        private List<Provider> filteredProviders;

        public List<Provider> FilteredProviders
        {
            get
            {
                return filteredProviders;
            }
            set
            {
                filteredProviders = value;
                OnPropertyChanged();
            }
        }

        private Provider selectedProvider;

        public Provider SelectedProvider
        {
            get
            {
                return selectedProvider;
            }
            set
            {
                selectedProvider = value;
                OnPropertyChanged();
                OnSelectedProviderChanged();
            }
        }

        private List<Buyer> filteredBuyers;

        public List<Buyer> FilteredBuyers
        {
            get
            {
                return filteredBuyers;
            }
            set
            {
                filteredBuyers = value;
                OnPropertyChanged();
            }
        }

        private Buyer selectedBuyer;

        public Buyer SelectedBuyer
        {
            get
            {
                return selectedBuyer;
            }
            set
            {
                selectedBuyer = value;
                OnPropertyChanged();
                OnSelectedBuyerChanged();
            }
        }

        private List<Contract> filteredContracts;

        public List<Contract> FilteredContracts
        {
            get
            {
                return filteredContracts;
            }
            set
            {
                filteredContracts = value;
                OnPropertyChanged();
            }
        }

        private Contract selectedContract;

        public Contract SelectedContract
        {
            get
            {
                return selectedContract;
            }
            set
            {
                if (selectedContract == value) return;

                selectedContract = value;
                OnPropertyChanged();
                OnSelectedContractChanged();
            }
        }

        private void OnSelectedProviderChanged()
        {
            if (selectedContract == null)
            {
                if (selectedBuyer == null)
                {
                    FilteredContracts = allContracts.Where(c => c.Provider == selectedProvider).ToList();
                }
                else
                {
                    FilteredContracts = allContracts.Where(c => c.Provider == selectedProvider && c.Buyer == selectedBuyer).ToList();
                }

                FilteredBuyers = FilteredContracts.Select(c => c.Buyer).Distinct().ToList();
            }
        }

        private void OnSelectedBuyerChanged()
        {
            if (selectedContract == null)
            {
                if (selectedProvider == null)
                {
                    FilteredContracts = allContracts.Where(c => c.Buyer == selectedBuyer).ToList();
                }
                else
                {
                    FilteredContracts = allContracts.Where(c => c.Provider == selectedProvider && c.Buyer == selectedBuyer).ToList();
                }

                FilteredProviders = FilteredContracts.Select(c => c.Provider).Distinct().ToList();
            }
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
            var provider1 = new Provider { Name = "Provider1" };
            var provider2 = new Provider { Name = "Provider2" };

            var buyer1 = new Buyer { Name = "Buyer1", DateOfBirth = new DateTime(1990, 1, 1) };
            var buyer2 = new Buyer { Name = "Buyer2", DateOfBirth = new DateTime(1990, 2, 2) };

            var contract1 = new Contract { Number = "1", Provider = provider1, Buyer = buyer1 };
            var contract2 = new Contract { Number = "2", Provider = provider2, Buyer = buyer2 };
            var contract3 = new Contract { Number = "4", Provider = provider1, Buyer = buyer2 };

            allProviders = new List<Provider>(new[] { provider1, provider2 });
            allBuyers = new List<Buyer>(new[] { buyer1, buyer2 });
            allContracts = new List<Contract>(new[] { contract1, contract2,  contract3 });

            filteredProviders = allProviders;
            filteredBuyers = allBuyers;
            filteredContracts = allContracts;
        }
    }
}
