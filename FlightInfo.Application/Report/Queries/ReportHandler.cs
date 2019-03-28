using AutoMapper;
using AutoMapper.QueryableExtensions;
using FlightInfo.Application.Exceptions;
using FlightInfo.Domain.Entities;
using FlightInfo.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightInfo.Application.Report.Queries
{
    public class ReportHandler : IRequestHandler<ReportQuery, ReportModel>
    {

        private readonly FlightInfoDbContext _context;
        private readonly IMapper _mapper;
        public ReportHandler(FlightInfoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ReportModel> Handle(ReportQuery request, CancellationToken cancellationToken)
        {
            List<ReportLookupModel> records = new List<ReportLookupModel>();
            var query = _context.Flights.AsQueryable();
            if (request.DepartureAirportId.HasValue)
            {
                var entity = await _context.Airports
              .SingleOrDefaultAsync(c => c.AirportId == request.DepartureAirportId, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Airport), request.DepartureAirportId);
                }
                query = query.Where(filter => filter.DepartureAirportId == request.DepartureAirportId.Value);
            }
            if (request.DestinationAirportId.HasValue)
            {
                var entity = await _context.Airports
             .SingleOrDefaultAsync(c => c.AirportId == request.DepartureAirportId, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Airport), request.DepartureAirportId);
                }
                query = query.Where(filter => filter.DestinationAirportId == request.DestinationAirportId.Value);
            }
            records = await query.ProjectTo<ReportLookupModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new ReportModel() { Data = records };

        }
    }
}
