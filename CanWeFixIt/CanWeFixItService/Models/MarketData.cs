namespace CanWeFixItService.Models
{
    public class MarketData
    {
        public int Id { get; set; }
        public long? DataValue { get; set; }
        public string Sedol { get; set; }
        public bool Active { get; set; }
    }

    public class MarketDataDto
    {
        public MarketDataDto(MarketData marketData, int instrumentId)
        {
            Id = marketData.Id;
            DataValue = marketData.DataValue;
            InstrumentId = instrumentId;
            Active = marketData.Active;
        }

        public int Id { get; set; }
        public long? DataValue { get; set; }
        public int? InstrumentId { get; set; }
        public bool Active { get; set; }
    }
}