using CanWeFixItService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CanWeFixItService.Services
{
    public interface IInstrumentService
    {
        Task<IEnumerable<Instrument>> GetInstrumentsAsync();
    }
}
