using System;
using System.Collections.Generic;
using System.Text;

namespace FlightInfo.Domain.Entities
{
    public class Flight
    {
        public int? DepartureAirportId { get; set; }
        public virtual Airport DepartureAirport { get; set; }
        public virtual Airport DestinationAirport { get; set; }
        public int? DestinationAirportId { get; set; }
        public decimal FuelConsumption { get; set; }
        public double Distance { get; set; }
    }
}
