using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlightInfo.Application.Flights.Queries;
using Microsoft.AspNetCore.Cors;
using FlightInfo.Application.Flights.Commands.UpdateFlight;
using FlightInfo.Application.FlightInfo;

namespace FlightInfo.WebApi.Controllers
{
    [EnableCors("AllowUI")]
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class FlightInfoController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<AirportSearchModel>> FilterAirports(string textFilter)
        {
            return await Mediator.Send(new AirportSearchQuery() { TextFilter = textFilter });
        }
        [HttpPost]
        public async Task<ActionResult<FuelConsumptionModel>> FlightFuelConsumption([FromBody]GetFuelConsumptionQuery fuelConsumptionQuery)
        {
            return await Mediator.Send(fuelConsumptionQuery);
        }

        [HttpGet]
        public async Task<IActionResult> Flights(int? departureAirport, int? destinationAirport, int? page, int? limit)
        {
            var x = await Mediator.Send(new FlightInfoQuery() { DepartureAirportId = departureAirport, DestinationAirportId = destinationAirport, Page = page, Limit = limit });
            return new JsonResult(new { records = x.Data, total = x.TotalRows });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFlight(UpdateFlightCommand updateFlightCommand)
        {
            await Mediator.Send(updateFlightCommand);
            return NoContent();
        }
    }
}