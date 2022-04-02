using CanWeFixItService.Models;
using CanWeFixItService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CanWeFixItApi.Controllers
{
    [ApiController]
    [Route("v1/valuations")]
    public class ValuationsController : ControllerBase
    {
        private readonly IMarketDataService _marketDataService;

        public ValuationsController(IMarketDataService marketDataService)
        {
            _marketDataService = marketDataService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketValuation>>> GetValuationsTotal()
        {
            return Ok(await _marketDataService.GetValuationsAsync());
        }
    }
}
