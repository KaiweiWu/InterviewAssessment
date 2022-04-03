using CanWeFixItService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CanWeFixItService.Services
{
    public interface IMarketDataService
    {
        Task<IEnumerable<MarketDataDto>> GetMarketDataAsync();
        Task<IEnumerable<MarketValuation>> GetValuationsAsync();
    }
}
