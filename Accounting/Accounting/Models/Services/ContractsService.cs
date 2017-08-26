using System;
using System.Collections.Generic;
using System.Linq;

namespace Accounting.Models.Services
{
    public class ContractsService
    {
        private List<Provider> allProviders;
        private List<Buyer> allBuyers;
        private List<Contract> allContracts;

        public ContractsService()
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
            allContracts = new List<Contract>(new[] { contract1, contract2, contract3 });
        }

        public List<Contract> GetContractsBy(Provider provider)
        {
            return allContracts.Where(c => c.Provider == provider).ToList();
        }
        
        public List<Contract> GetContractsBy(Buyer buyer)
        {
            return allContracts.Where(c => c.Buyer == buyer).ToList();
        }

        public List<Contract> GetContractsBy(Provider provider, Buyer buyer)
        {
            return allContracts.Where(c => c.Provider == provider && c.Buyer == buyer).ToList();
        }

        public List<Contract> GetAllContracts()
        {
            return allContracts;
        }
    }
}
