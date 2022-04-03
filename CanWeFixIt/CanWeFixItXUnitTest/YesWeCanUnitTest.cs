using CanWeFixItApi.Controllers;
using CanWeFixItService;
using CanWeFixItService.Models;
using CanWeFixItService.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CanWeFixItXUnitTest
{
    public class YesWeCanUnitTest
    {
        readonly Mock<IDatabaseService> mockDatabase = new();

        public YesWeCanUnitTest()
        {
            // Setup and filter mock data by active
            mockDatabase.Setup(service => service.MarketData()).ReturnsAsync(GetTestMarketData().Where(data => data.Active));
            mockDatabase.Setup(service => service.Instruments()).ReturnsAsync(GetTestInstrumentData().Where(data => data.Active));
        }

        [Fact]
        public async Task ValidateMarketData()
        {
            var mockService = new Mock<MarketDataService>(mockDatabase.Object);
            var controller = new MarketDataController(mockService.Object);

            // Act
            var actionResult = await controller.GetMarketData();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var returnValue = Assert.IsAssignableFrom<IEnumerable<MarketDataDto>>(result.Value);

            Assert.Equal(2, returnValue.Count());
            Assert.True(returnValue.All(d => d.Id is 2 or 4));
            Assert.True(returnValue.All(d => d.InstrumentId is 2 or 4));
        }

        [Fact]
        public async Task ValidateInstrumentData()
        {
            var mockService = new Mock<InstrumentService>(mockDatabase.Object);
            var controller = new InstrumentController(mockService.Object);

            // Act
            var actionResult = await controller.GetInstruments();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var returnValue = Assert.IsAssignableFrom<IEnumerable<Instrument>>(result.Value);

            Assert.Equal(4, returnValue.Count());
            Assert.True(returnValue.All(d => d.Id is 2 or 4 or 6 or 8));
        }

        [Fact]
        public async Task ValidateMarketValuationData()
        {
            var mockService = new Mock<MarketDataService>(mockDatabase.Object);
            var controller = new ValuationsController(mockService.Object);

            // Act
            var actionResult = await controller.GetValuationsTotal();


            // Assert
            var result = actionResult.Result as OkObjectResult;
            var returnValue = Assert.IsAssignableFrom<IEnumerable<MarketValuation>>(result.Value);

            var data = returnValue.First();
            Assert.Equal("DataValueTotal", data.Name);
            Assert.Equal(13332, data.Total);
        }

        private IEnumerable<Instrument> GetTestInstrumentData()
        {
            return new List<Instrument>
            {
                new Instrument() {
                    Id = 1,
                    Sedol = "Sedol1",
                    Name = "Name1",
                    Active = false
                },
                new Instrument()
                {
                    Id = 2,
                    Sedol = "Sedol2",
                    Name = "Name2",
                    Active = true
                },
                new Instrument()
                {
                    Id = 3,
                    Sedol = "Sedol3",
                    Name = "Name3",
                    Active = false
                },
                new Instrument()
                {
                    Id = 4,
                    Sedol = "Sedol4",
                    Name = "Name4",
                    Active = true
                },
                new Instrument()
                {
                    Id = 5,
                    Sedol = "Sedol5",
                    Name = "Name5",
                    Active = false
                },
                new Instrument()
                {
                    Id = 6,
                    Sedol = "",
                    Name = "Name6",
                    Active = true
                },
                new Instrument()
                {
                    Id = 7,
                    Sedol = "Sedol7",
                    Name = "Name7",
                    Active = false
                },
                new Instrument()
                {
                    Id = 8,
                    Sedol = "Sedol8",
                    Name = "Name8",
                    Active = true
                }
            };
        }

        private IEnumerable<MarketData> GetTestMarketData()
        {
            return new List<MarketData>
            {
                new MarketData()
                {
                    Id = 1,
                    DataValue = 1111,
                    Sedol = "Sedol1",
                    Active = false
                },
                new MarketData()
                {
                    Id = 2,
                    DataValue = 2222,
                    Sedol = "Sedol2",
                    Active = true
                },
                new MarketData()
                {
                    Id = 3,
                    DataValue = 3333,
                    Sedol = "Sedol3",
                    Active = false
                },
                new MarketData()
                {
                    Id = 4,
                    DataValue = 4444,
                    Sedol = "Sedol4",
                    Active = true
                },
                new MarketData()
                {
                    Id = 5,
                    DataValue = 5555,
                    Sedol = "Sedol5",
                    Active = false
                },
                new MarketData()
                {
                    Id = 6,
                    DataValue = 6666,
                    Sedol = "Sedol6",
                    Active = true
                }
            };
        }
    }
}
