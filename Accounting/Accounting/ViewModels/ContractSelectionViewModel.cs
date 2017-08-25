using Accounting.Models;
using System;
using System.Collections.ObjectModel;

namespace Accounting.ViewModels
{
    class ContractSelectionViewModel
    {
        public ObservableCollection<Contract> Contracts { get; set; }

        public Contract SelectedContract { get; set; }

        public ContractSelectionViewModel()
        {
            var provider1 = new Provider { Name = "Provider1" };
            var provider2 = new Provider { Name = "Provider2" };

            var buyer1 = new Buyer { Name = "Buyer1", DateOfBirth = new DateTime(1990, 1, 1) };
            var buyer2 = new Buyer { Name = "Buyer2", DateOfBirth = new DateTime(1990, 2, 2) };

            var contract1 = new Contract { Number = "1", Provider = provider1, Buyer = buyer1 };
            var contract2 = new Contract { Number = "2", Provider = provider2, Buyer = buyer2 };
        }
    }
}
