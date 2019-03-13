using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightInfo.Application.Flights.Queries
{
    public class AirportSearchQuery : IRequest<AirportSearchModel>
    {
        public string TextFilter { get; set; }
    }
}
