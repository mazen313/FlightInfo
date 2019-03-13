using FlightInfo.Test.Flights.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FlightInfo.Test
{
    public class RunTest
    {
        [Fact]
        public async System.Threading.Tasks.Task Test1Async()
        {
            GetFuelConsumptionQueryHandlerTest home = new GetFuelConsumptionQueryHandlerTest(new Infrastructure.QueryTestFixture());
            await home.GetFuelConsumption();
            Assert.Equal(1, 1);
        }
        [Fact]

        public void test()
        {
            Assert.Equal(1, 1);
        }
    }
}
