using FlightInfo.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FlightInfoDbContext>();
            FlightInfoDbContext context = new FlightInfoDbContext(builder.Options);
            FlightInfoInitializer.Initialize(context);
        }
    }
}
