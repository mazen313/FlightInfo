using System;
using System.Collections.Generic;
using System.Text;
using FlightInfo.Persistence.Infrastucture;
using Microsoft.EntityFrameworkCore;

namespace FlightInfo.Persistence
{
    public class FlightInfoDbContextFactory : DesignTimeDbContextFactoryBase<FlightInfoDbContext>
    {
        protected override FlightInfoDbContext CreateNewInstance(DbContextOptions<FlightInfoDbContext> options)
        {
            return new FlightInfoDbContext(options);
        }
    }
}