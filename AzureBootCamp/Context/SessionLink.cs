using System;
using System.Collections.Generic;

#nullable disable

namespace AzureBootCamp.Context
{
    public partial class SessionLink
    {
        public int SessionLinkId { get; set; }
        public string SessionLinkValue { get; set; }
        public int TrackId { get; set; }
        public DateTime SessionTime { get; set; }

        public virtual Track Track { get; set; }
    }
}
