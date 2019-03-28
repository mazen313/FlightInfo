using AutoMapper;
using FlightInfo.Application.FlightInfo;
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
    public class FlightQueryHandlerTest
    {
        private readonly FlightInfoDbContext _context;
        private readonly IMapper _mapper;
        public FlightQueryHandlerTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            var myProfile = new AutoMapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
        }
        public async Task GetFlightInfo()
        {
            var handler = new FlightInfoHandler(_context, _mapper);

            var result = await handler.Handle(new FlightInfoQuery (), CancellationToken.None);
            result.ShouldBeOfType<FlightInfoModel>();
            result.Data.Count.ShouldBeGreaterThan(0);
        }
    }
}
