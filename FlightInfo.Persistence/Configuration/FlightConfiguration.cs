using FlightInfo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightInfo.Persistence.Configuration
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(e => new { e.DepartureAirportId, e.DestinationAirportId });
            builder.HasOne(e => e.DepartureAirport).WithMany(g => g.DepartureFlights).HasForeignKey(fkey => fkey.DepartureAirportId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.DestinationAirport).WithMany(g => g.DestinationFlights).HasForeignKey(fkey => fkey.DestinationAirportId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
