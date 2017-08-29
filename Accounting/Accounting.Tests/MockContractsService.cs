using Accounting.Models.Services;
using System.Collections.Generic;
using Accounting.Models;
using System.Linq;

namespace Accounting.Tests
{
    class MockContractsService : IContractsService
    {
        public List<Contract> Contracts { get; set; }

        public MockContractsService()
        {
            Contracts = new List<Contract>();
        }

        public List<Contract> GetAllContracts()
        {
            return Contracts;
        }

        public List<Contract> GetContractsBy(Buyer buyer)
        {
            return Contracts.Where(c => c.Buyer == buyer).ToList();
        }

        public List<Contract> GetContractsBy(Provider provider)
        {
            return Contracts.Where(c => c.Provider == provider).ToList();
        }

        public List<Contract> GetContractsBy(Provider provider, Buyer buyer)
        {
            return Contracts.Where(c => c.Provider == provider && c.Buyer == buyer ).ToList();
        }
    }
}
