using AutoMapper;
using FlightInfo.Application.Flights.Queries;
using FlightInfo.Application.Infrastructure.Automapper;
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
    public class AirportSearchQueryHandlerTest
    {
        private readonly FlightInfoDbContext _context;
        private readonly IMapper _mapper;

        public AirportSearchQueryHandlerTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            var myProfile = new AutoMapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
        }

        public async Task TestAirportSearch()
        {
            var handler = new AirportSearchQueryHandler(_context, _mapper);

            var result = await handler.Handle(new AirportSearchQuery { TextFilter="a" }, CancellationToken.None);
            result.ShouldBeOfType<AirportSearchModel>();
            result.Airports.Count.ShouldBeGreaterThan(0);
        }
    }
}
