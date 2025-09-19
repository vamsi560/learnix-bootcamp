using AzureBootCamp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureBootCamp.Models
{
    public class SessionModel
    {
        public Topic Topic { get; set; }
        public SessionLink SessionLink { get; set; }
    }
}
