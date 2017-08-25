using Accounting.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Accounting.ViewModels
{
    public class ContractSelectionViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Provider> Providers { get; set; }

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

        public ObservableCollection<Buyer> Buyers { get; set; }

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

        public ObservableCollection<Contract> Contracts { get; set; }

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

            Providers = new ObservableCollection<Provider>(new[] { provider1, provider2 });
            Buyers = new ObservableCollection<Buyer>(new[] { buyer1, buyer2 });
            Contracts = new ObservableCollection<Contract>(new[] { contract1, contract2 });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
