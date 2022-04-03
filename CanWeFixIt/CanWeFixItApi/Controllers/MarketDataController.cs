using System.Collections.Generic;
using System.Threading.Tasks;
using CanWeFixItService.Models;
using CanWeFixItService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CanWeFixItApi.Controllers
{
    [ApiController]
    [Route("v1/marketdata")]
    public class MarketDataController : ControllerBase
    {
        private readonly IMarketDataService _marketDataService;

        public MarketDataController(IMarketDataService marketDataService)
        {
            _marketDataService = marketDataService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketDataDto>>> GetMarketData()
        {
            return Ok(await _marketDataService.GetMarketDataAsync());
        }
    }
}