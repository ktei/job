using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiveMeCounts.Services.Google
{
    /// <summary>
    /// This is just one of the possible implementations of ICounterService, which
    /// uses Google. We could have other implementations such as BingCounterService, which
    /// uses MS Bing service.
    /// </summary>
    public class GoogleCounterService : ICounterService
    {
        public int GetCount(string keywords, string url)
        {
            throw new NotImplementedException();
        }
    }
}