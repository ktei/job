using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiveMeCounts.Models
{
    public class GetCountRequest
    {
        public string keywords { get; set; }
        public string url { get; set; }
    }
}