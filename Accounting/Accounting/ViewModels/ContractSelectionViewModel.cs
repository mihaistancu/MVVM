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
            Contracts = new ObservableCollection<Contract>(new []
            {
                new Contract
                {
                    Number = "1",
                    Provider = new Provider
                    {
                        Name = "Provider1"
                    },
                    Buyer=new Buyer
                    {
                        Name = "Buyer1",
                        DateOfBirth = new DateTime(1990,1,1)
                    }
                },
                new Contract
                {
                    Number = "2",
                    Provider = new Provider
                    {
                        Name = "Provider2"
                    },
                    Buyer=new Buyer
                    {
                        Name = "Buyer2",
                        DateOfBirth = new DateTime(1990,2,2)
                    }
                }
            });
        }
    }
}
