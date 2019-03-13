using FlightInfo.Application.Flights.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightInfo.Application.Flights.Commands.UpdateFlight
{
    public class UpdateFlightCommand : IRequest
    {
        public int DepartureAirportId { get; set; }
        public int DestinationAirportId { get; set; }
        public decimal FuelConsumption { get; set; }
        public double Distance { get; set; }
    }
}
