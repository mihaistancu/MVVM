using System.Collections.Generic;

namespace Accounting.Models.Services
{
    public interface IContractsService
    {
        List<Contract> GetAllContracts();
        List<Contract> GetContractsBy(Provider provider);
        List<Contract> GetContractsBy(Buyer buyer);
        List<Contract> GetContractsBy(Provider provider, Buyer buyer);
    }
}