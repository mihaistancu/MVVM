using Accounting.Models;
using System;
using System.Collections.ObjectModel;

namespace Accounting.ViewModels
{
    public class ContractSelectionViewModel
    {
        public ObservableCollection<Provider> Providers { get; set; }

        public Provider SelectedProvider { get; set; }

        public ObservableCollection<Buyer> Buyers { get; set; }

        public Buyer SelectedBuyer { get; set; }

        public ObservableCollection<Contract> Contracts { get; set; }

        private Contract selectedContract { get; set; }

        public Contract SelectedContract
        {
            get
            {
                return selectedContract;
            }
            set
            {
                selectedContract = value;
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
    }
}
