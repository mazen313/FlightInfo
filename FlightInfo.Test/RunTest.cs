using FlightInfo.Test.Flights.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FlightInfo.Test
{
    public class RunTest
    {
        [Fact]
        public async Task TestFuelConsumption()
        {
            GetFuelConsumptionQueryHandlerTest fuelConsumptionQueryHandlerTest = new GetFuelConsumptionQueryHandlerTest(new Infrastructure.QueryTestFixture());
            await fuelConsumptionQueryHandlerTest.GetFuelConsumption();
        }

        [Fact]
        public async Task TestFuelConsumptionCreate()
        {
            GetFuelConsumptionQueryHandlerTest fuelConsumptionQueryHandlerTest = new GetFuelConsumptionQueryHandlerTest(new Infrastructure.QueryTestFixture());
            await fuelConsumptionQueryHandlerTest.GetFuelConsumptionCreate();
        }
        [Fact]

        public async Task TestFlightInfo()
        {
            FlightQueryHandlerTest flightQueryHandlerTest = new FlightQueryHandlerTest(new Infrastructure.QueryTestFixture());
            await flightQueryHandlerTest.GetFlightInfo();;
        }
        [Fact]
        public async Task TestUpdateFlightInfoCommnd()
        {
            UpdateFlightCommandHandlerTest updateFlightCommandHandlerTestu = new UpdateFlightCommandHandlerTest(new Infrastructure.QueryTestFixture());
            await updateFlightCommandHandlerTestu.UpdateFlightInfoCommandHandlerTest();
        }

        [Fact]
        public async Task TestAirportFilter()
        {
            AirportSearchQueryHandlerTest airportSearchQueryHandlerTest = new AirportSearchQueryHandlerTest(new Infrastructure.QueryTestFixture());
            await airportSearchQueryHandlerTest.TestAirportSearch();
        }

        [Fact]
        public void TestUpdateFlightInfoExceptionCommnd()
        {
            UpdateFlightCommandHandlerTest updateFlightCommandHandlerTestu = new UpdateFlightCommandHandlerTest(new Infrastructure.QueryTestFixture());
            updateFlightCommandHandlerTestu.UpdateFlightInfoCommandHandlerTestException(); 
        }
        
    }

}
