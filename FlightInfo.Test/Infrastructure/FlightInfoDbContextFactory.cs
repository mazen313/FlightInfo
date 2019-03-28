using FlightInfo.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FlightInfo.Domain.Entities;

namespace FlightInfo.Test.Infrastructure
{
    public class FlightInfoDbContextFactory
    {
        public static FlightInfoDbContext Create()
        {
            var options = new DbContextOptionsBuilder<FlightInfoDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new FlightInfoDbContext(options);

            context.Database.EnsureCreated();
            context.Airports.AddRange(new[]{
                new Airport{ AirportId=1,Name="Chris Hadfield Airport", City="Sarnia",Country="Canada", IATA="YZR",ICAO="CYZR", Longitude= 42.9994010925293M, Altitude=-82.30889892578125M },
                new Airport{ AirportId=2,Name="Leicester Airport", City="Leicester",Country="United Kingdom", IATA=string.Empty,ICAO="EGBG", Longitude= 52.6077995300293M, Altitude=1.03193998336792M },
                new Airport{ AirportId=3,Name="RAF Wyton", City="Wyton",Country="United Kingdom", IATA="QUY",ICAO="EGUY", Longitude= 52.3572006226M, Altitude=-0.107832998037M},
                new Airport{ AirportId=4,Name="Lidköping-Hovby Airport", City="Lidkoping",Country="Sweden", IATA="LDK",ICAO="ESGL", Longitude= 58.4655M, Altitude=13.1744M}
                });
            context.Flights.AddRange(new[] {
                new Flight { DepartureAirportId=1, DestinationAirportId=4, FuelConsumption=10M },
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(FlightInfoDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
