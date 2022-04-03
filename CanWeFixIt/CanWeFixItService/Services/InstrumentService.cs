using CanWeFixItService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CanWeFixItService.Services
{
    public class InstrumentService : IInstrumentService
    {
        private readonly IDatabaseService _database;

        public InstrumentService(IDatabaseService database)
        {
            _database = database;
        }

        public async Task<IEnumerable<Instrument>> GetInstrumentsAsync()
        {
            return await _database.Instruments();
        }
    }
}
