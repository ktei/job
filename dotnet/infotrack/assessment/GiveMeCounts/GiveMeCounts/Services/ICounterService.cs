using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiveMeCounts.Services
{
    public interface ICounterService
    {
        int GetCount(string keywords, string url);
    }
}