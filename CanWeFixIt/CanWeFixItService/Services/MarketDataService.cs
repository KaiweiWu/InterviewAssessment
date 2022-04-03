using CanWeFixItService.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanWeFixItService.Services
{
    public class MarketDataService : IMarketDataService
    {
        private readonly IDatabaseService _database;

        public MarketDataService(IDatabaseService database)
        {
            _database = database;
        }

        public async Task<IEnumerable<MarketDataDto>> GetMarketDataAsync()
        {
            var marketData = await _database.MarketData();
            var instruments = await _database.Instruments();

            var marketDataResult = from m in marketData join i in instruments on m.Sedol equals i.Sedol select new MarketDataDto(m, i.Id);

            return marketDataResult;
        }

        public async Task<IEnumerable<MarketValuation>> GetValuationsAsync()
        {
            var marketData = await _database.MarketData();

            var marketValuation = new MarketValuation
            {
                Total = marketData.Select(m => m.DataValue ?? 0).Sum()
            };

            // Cast to single item list
            return new List<MarketValuation> { marketValuation };
        }
    }
}
