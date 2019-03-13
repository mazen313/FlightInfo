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
