using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightInfo.Application.FlightInfo
{
    public class FlightInfoQuery : IRequest<FlightInfoModel>
    {
        public int? DepartureAirportId { get; set; }
        public int? DestinationAirportId { get; set; }
        public int? Page { get; set; }
        public int? Limit { get; set; }
        public int TotalRows { get; set; }
    }
}
