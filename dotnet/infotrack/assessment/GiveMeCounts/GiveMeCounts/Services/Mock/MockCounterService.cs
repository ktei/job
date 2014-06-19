using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiveMeCounts.Services.Mock
{
    /// <summary>
    /// Just a mock implementation for ICounterService. We can bind this
    /// for unit testing.
    /// </summary>
    public class MockCounterService : ICounterService
    {
        public int GetCount(string keywords, string url)
        {
            return 10;
        }
    }
}