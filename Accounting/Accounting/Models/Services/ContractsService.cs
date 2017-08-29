using Accounting.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Accounting.Models.Services
{
    public class ContractsService
    {
        public ContractsService()
        {
            using (var dbContext = new ContractsDbContext())
            {
                dbContext.Providers.RemoveRange(dbContext.Providers);
                dbContext.Buyers.RemoveRange(dbContext.Buyers);
                dbContext.Contracts.RemoveRange(dbContext.Contracts);

                var provider1 = new Provider { Name = "Provider1" };
                var provider2 = new Provider { Name = "Provider2" };

                var buyer1 = new Buyer { Name = "Buyer1", DateOfBirth = new DateTime(1990, 1, 1) };
                var buyer2 = new Buyer { Name = "Buyer2", DateOfBirth = new DateTime(1990, 2, 2) };

                var contract1 = new Contract { Number = "1", Provider = provider1, Buyer = buyer1 };
                var contract2 = new Contract { Number = "2", Provider = provider2, Buyer = buyer2 };
                var contract3 = new Contract { Number = "4", Provider = provider1, Buyer = buyer2 };

                dbContext.Contracts.AddRange(new[] { contract1, contract2, contract3 });
                dbContext.SaveChanges();
            }
        }

        public List<Contract> GetContractsBy(Provider provider)
        {
            using (var dbContext = new ContractsDbContext())
            {
                return dbContext.Contracts.Where(c => c.Provider == provider).ToList();
            }   
        }
        
        public List<Contract> GetContractsBy(Buyer buyer)
        {
            using (var dbContext = new ContractsDbContext())
            {
                return dbContext.Contracts.Where(c => c.Buyer == buyer).ToList();
            }   
        }

        public List<Contract> GetContractsBy(Provider provider, Buyer buyer)
        {
            using (var dbContext = new ContractsDbContext())
            {
                return dbContext.Contracts.Where(c => c.Provider == provider && c.Buyer == buyer).ToList();
            }
        }

        public List<Contract> GetAllContracts()
        {
            using (var dbContext = new ContractsDbContext())
            {
                return dbContext.Contracts
                    .Include(c => c.Provider)
                    .Include(c => c.Buyer)
                    .ToList();
            }
        }
    }
}
