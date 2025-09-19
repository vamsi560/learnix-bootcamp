using System;
using System.Collections.Generic;

#nullable disable

namespace AzureBootCamp.Context
{
    public partial class Track
    {
        public Track()
        {
            SessionLinks = new HashSet<SessionLink>();
            Topics = new HashSet<Topic>();
        }

        public int TrackId { get; set; }
        public string TrackName { get; set; }

        public virtual ICollection<SessionLink> SessionLinks { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
