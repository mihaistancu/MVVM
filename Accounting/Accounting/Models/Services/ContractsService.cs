using Accounting.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Accounting.Models.Services
{
    public class ContractsService : IContractsService
    {
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
