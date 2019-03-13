using CsvHelper;
using FlightInfo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FlightInfo.Persistence
{
    public class FlightInfoDbContext : DbContext
    {
        public FlightInfoDbContext(DbContextOptions<FlightInfoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FlightInfoDbContext).Assembly);
        }

    }

}
