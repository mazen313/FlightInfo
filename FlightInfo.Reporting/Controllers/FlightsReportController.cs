using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlightInfo.Reporting.Models;
using Rotativa.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FlightInfo.Application.Flights.Queries;
using FlightInfo.Application.Report.Queries;
using Microsoft.AspNetCore.Cors;

namespace FlightInfo.Reporting.Controllers
{
    [EnableCors("AllowUI")]
    public class FlightsReportController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Info(int? DepartureAirportId, int? DestinationAirportId)
        {
            var x = await Mediator.Send(new ReportQuery() { DepartureAirportId = DepartureAirportId, DestinationAirportId = DestinationAirportId });
            return new Rotativa.AspNetCore.ViewAsPdf("Info", x.Data) { FileName="Summary Report.pdf" };
        }
    }
}
