using System;
using System.Collections.Generic;

#nullable disable

namespace AzureBootCamp.Context
{
    public partial class Topic
    {
        public Topic()
        {
            TopicSpeakers = new HashSet<TopicSpeaker>();
        }

        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public string TopicDescription { get; set; }
        public string TopicTime { get; set; }
        public string TopicImage { get; set; }
        public int TrackId { get; set; }
        public int? OrderNo { get; set; }
        public bool? IsActive { get; set; }

        public virtual Track Track { get; set; }
        public virtual ICollection<TopicSpeaker> TopicSpeakers { get; set; }
    }
}
