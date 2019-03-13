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

namespace FlightInfo.Application.FlightInfo
{

    public class FlightInfoHandler : IRequestHandler<FlightInfoQuery, FlightInfoModel>
    {

        private readonly FlightInfoDbContext _context;
        private readonly IMapper _mapper;
        public FlightInfoHandler(FlightInfoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<FlightInfoModel> Handle(FlightInfoQuery request, CancellationToken cancellationToken)
        {
            List<FlightInfoLookupModel> records = new List<FlightInfoLookupModel>();
            var query = _context.Flights.AsQueryable();
            if (request.DepartureAirportId.HasValue)
            {
                query = query.Where(filter => filter.DepartureAirportId == request.DepartureAirportId.Value);
            }
            if (request.DestinationAirportId.HasValue)
            {
                query = query.Where(filter => filter.DestinationAirportId == request.DestinationAirportId.Value);
            }
            int count = await query.CountAsync();
            if (request.Page.HasValue && request.Limit.HasValue)
            {
                int start = (request.Page.Value - 1) * request.Limit.Value;
                query = query.Skip(start).Take(request.Limit.Value);
            }
            records = await query.ProjectTo<FlightInfoLookupModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new FlightInfoModel() { TotalRows = count, Data = records };

        }
    }
}
