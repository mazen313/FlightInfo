using FlightInfo.Application.Exceptions;
using FlightInfo.Application.Flights.Commands.UpdateFlight;
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
    public class UpdateFlightCommandHandlerTest
    {
        private readonly FlightInfoDbContext _context;
        public UpdateFlightCommandHandlerTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }
        public async Task UpdateFlightInfoCommandHandlerTest()
        {
            var handler = new UpdateFlightCommandHandler(_context);

            var result = await handler.Handle(new UpdateFlightCommand { DepartureAirportId = 1, DestinationAirportId = 4, Distance=2345.45, FuelConsumption=1244.45M }, CancellationToken.None);
            result.ShouldBeOfType<MediatR.Unit>();
            result.ShouldNotBeNull();
        }

        public void UpdateFlightInfoCommandHandlerTestException()
        {
            var handler = new UpdateFlightCommandHandler(_context);
            Should.Throw<NotFoundException>(async () => await handler.Handle(new UpdateFlightCommand { DepartureAirportId = 1, DestinationAirportId = 7, Distance = 2345.45, FuelConsumption = 1244.45M }, CancellationToken.None));
        }
    }
}
