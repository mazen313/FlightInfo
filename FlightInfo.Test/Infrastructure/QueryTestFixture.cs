using FlightInfo.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FlightInfo.Test.Infrastructure
{
    public class QueryTestFixture : IDisposable
    {
        public FlightInfoDbContext Context { get; private set; }

        public QueryTestFixture()
        {
            Context = FlightInfoDbContextFactory.Create();
        }

        public void Dispose()
        {
            FlightInfoDbContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}

