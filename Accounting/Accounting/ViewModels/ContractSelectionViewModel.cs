using Accounting.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Accounting.ViewModels
{
    public class ContractSelectionViewModel : INotifyPropertyChanged
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
                selectedContract = value;
                OnPropertyChanged();

                SelectedProvider = selectedContract.Provider;
                SelectedBuyer = selectedContract.Buyer;

                FilteredProviders = new List<Provider> { selectedContract.Provider };
                FilteredBuyers = new List<Buyer> { selectedContract.Buyer };
                FilteredContracts = new List<Contract> { selectedContract };
            }
        }

        public ContractSelectionViewModel()
        {
            var provider1 = new Provider { Name = "Provider1" };
            var provider2 = new Provider { Name = "Provider2" };

            var buyer1 = new Buyer { Name = "Buyer1", DateOfBirth = new DateTime(1990, 1, 1) };
            var buyer2 = new Buyer { Name = "Buyer2", DateOfBirth = new DateTime(1990, 2, 2) };

            var contract1 = new Contract { Number = "1", Provider = provider1, Buyer = buyer1 };
            var contract2 = new Contract { Number = "2", Provider = provider2, Buyer = buyer2 };

            allProviders = new List<Provider>(new[] { provider1, provider2 });
            allBuyers = new List<Buyer>(new[] { buyer1, buyer2 });
            allContracts = new List<Contract>(new[] { contract1, contract2 });

            filteredProviders = allProviders;
            filteredBuyers = allBuyers;
            filteredContracts = allContracts;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
