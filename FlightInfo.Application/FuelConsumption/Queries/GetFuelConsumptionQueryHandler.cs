using FlightInfo.Persistence;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using FlightInfo.Domain.Entities;
using FlightInfo.Application.Exceptions;
using GeoCoordinatePortable;

namespace FlightInfo.Application.Flights.Queries
{
    public class GetFuelConsumptionQueryHandler : IRequestHandler<GetFuelConsumptionQuery, FuelConsumptionModel>
    {
        private readonly FlightInfoDbContext _context;

        public GetFuelConsumptionQueryHandler(FlightInfoDbContext context)
        {
            _context = context;
        }


        public async Task<FuelConsumptionModel> Handle(GetFuelConsumptionQuery request, CancellationToken cancellationToken)
        {
            var entityDeparture = await _context.Airports
               .SingleOrDefaultAsync(c => c.AirportId == request.DepartureAirportId, cancellationToken);

            if (entityDeparture == null)
            {
                throw new NotFoundException(nameof(Airport), request.DepartureAirportId);
            }

            var entityDestination = await _context.Airports
              .SingleOrDefaultAsync(c => c.AirportId == request.DestinationAirportId, cancellationToken);

            if (entityDeparture == null)
            {
                throw new NotFoundException(nameof(Airport), request.DestinationAirportId);
            }

            var queryResult = await _context.Flights.Where(filter => filter.DepartureAirportId == request.DepartureAirportId && filter.DestinationAirportId == request.DestinationAirportId).FirstOrDefaultAsync();
            if (queryResult == null)
            {
                double calculatedDistance = CalcualteDistanceBetweenAirports(entityDeparture, entityDestination);
                queryResult = new Flight()
                {
                    DepartureAirportId = request.DepartureAirportId,
                    DestinationAirportId = request.DestinationAirportId,
                    Distance = calculatedDistance,
                    FuelConsumption = CaculateFuelConsumption(calculatedDistance)
                };
                _context.Flights.Add(queryResult);
                await _context.SaveChangesAsync();
            }
            return new FuelConsumptionModel() { Consumption = queryResult.FuelConsumption, Distance = queryResult.Distance };
        }

        private decimal CaculateFuelConsumption(double distance)
        {
            // as the calculation formula is not clear ( we need alot of info to have an accurate calculation), we will consider a consumption of 4L/Km
            return Convert.ToDecimal(Math.Round(distance * 4, 3));
        }

        private double CalcualteDistanceBetweenAirports(Airport departure, Airport destination)
        {
            var departureCoord = new GeoCoordinate((double)departure.Latitude, (double)departure.Longitude);
            var destinationCoord = new GeoCoordinate((double)destination.Latitude, (double)destination.Longitude);
            return Math.Round(departureCoord.GetDistanceTo(destinationCoord) / 1000, 3);
        }
    }
}
