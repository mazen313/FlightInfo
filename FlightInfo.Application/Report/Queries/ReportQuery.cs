using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightInfo.Application.Report.Queries
{
    public class ReportQuery : IRequest<ReportModel>
    {
        public int? DepartureAirportId { get; set; }
        public int? DestinationAirportId { get; set; }
    }
}
