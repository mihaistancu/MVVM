using Accounting.Models;
using System.Collections.ObjectModel;

namespace Accounting.ViewModels
{
    class ContractSelectionViewModel
    {
        public ObservableCollection<Contract> Contracts { get; set; }

        public Contract SelectedContract { get; set; }
    }
}
