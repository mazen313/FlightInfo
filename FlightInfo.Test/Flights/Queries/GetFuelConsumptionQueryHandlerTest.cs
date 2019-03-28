using FlightInfo.Application.Flights.Queries;
using FlightInfo.Persistence;
using FlightInfo.Test.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FlightInfo.Test.Flights.Queries
{
    [Collection("QueryCollection")]
    public class GetFuelConsumptionQueryHandlerTest
    {
        private readonly FlightInfoDbContext _context;

        public GetFuelConsumptionQueryHandlerTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        public async Task GetFuelConsumption()
        {
            var handler= new GetFuelConsumptionQueryHandler(_context);

            var result = await handler.Handle(new GetFuelConsumptionQuery {  DepartureAirportId=1, DestinationAirportId=4 }, CancellationToken.None);
            result.ShouldBeOfType<FuelConsumptionModel>();
            result.Consumption.ShouldBeGreaterThan(0);
        }

        public async Task GetFuelConsumptionCreate()
        {
            var handler = new GetFuelConsumptionQueryHandler(_context);

            var result = await handler.Handle(new GetFuelConsumptionQuery { DepartureAirportId = 1, DestinationAirportId = 2 }, CancellationToken.None);
            result.ShouldBeOfType<FuelConsumptionModel>();
            result.Consumption.ShouldBeGreaterThan(0);
        }
    }
}
