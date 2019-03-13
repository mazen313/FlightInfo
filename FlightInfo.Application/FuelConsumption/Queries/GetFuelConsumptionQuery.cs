using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightInfo.Application.Flights.Queries
{
    public class GetFuelConsumptionQuery : IRequest<FuelConsumptionModel>
    {
        public int DepartureAirportId { get; set; }
        public int DestinationAirportId { get; set; }
    }
}
