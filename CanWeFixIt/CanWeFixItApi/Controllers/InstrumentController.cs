using System.Collections.Generic;
using System.Threading.Tasks;
using CanWeFixItService.Models;
using CanWeFixItService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CanWeFixItApi.Controllers
{
    [ApiController]
    [Route("v1/instruments")]
    public class InstrumentController : ControllerBase
    {
        private readonly IInstrumentService _instrumentService;
        
        public InstrumentController(IInstrumentService instrumentService)
        {
            _instrumentService = instrumentService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instrument>>> GetInstruments()
        {   
            return Ok(await _instrumentService.GetInstrumentsAsync());
        }
    }
}