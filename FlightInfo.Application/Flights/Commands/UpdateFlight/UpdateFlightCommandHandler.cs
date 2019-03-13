using FlightInfo.Application.Exceptions;
using FlightInfo.Domain.Entities;
using FlightInfo.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightInfo.Application.Flights.Commands.UpdateFlight
{
    public class UpdateFlightCommandHandler : IRequestHandler<UpdateFlightCommand, Unit>
    {
        private readonly FlightInfoDbContext _context;

        public UpdateFlightCommandHandler(FlightInfoDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Flights
               .SingleAsync(c => c.DepartureAirportId == request.DepartureAirportId && c.DestinationAirportId == request.DestinationAirportId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Flight), request.DepartureAirportId);
            }
            if (request.Distance != entity.Distance)
                entity.Distance = request.Distance;
            if (request.FuelConsumption != entity.FuelConsumption)
                entity.FuelConsumption = request.FuelConsumption;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
