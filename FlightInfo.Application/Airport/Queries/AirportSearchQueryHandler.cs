using AutoMapper;
using AutoMapper.QueryableExtensions;
using FlightInfo.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightInfo.Application.Flights.Queries
{
    public class AirportSearchQueryHandler : IRequestHandler<AirportSearchQuery, AirportSearchModel>
    {
        private readonly FlightInfoDbContext _context;
        private readonly IMapper _mapper;
        public AirportSearchQueryHandler(FlightInfoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AirportSearchModel> Handle(AirportSearchQuery request, CancellationToken cancellationToken)
        {
            var results = await _context.Airports.Where(filter => filter.Name.Contains(request.TextFilter) || filter.City.Contains(request.TextFilter) || filter.Country.Contains(request.TextFilter)).Take(10).ProjectTo<AirportSearchLookupModel>(_mapper.ConfigurationProvider).ToListAsync();
            return new AirportSearchModel() { Airports = results };
        }

    }
}
