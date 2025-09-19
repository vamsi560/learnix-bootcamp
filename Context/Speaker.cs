using System;
using System.Collections.Generic;

#nullable disable

namespace AzureBootCamp.Context
{
    public partial class Speaker
    {
        public Speaker()
        {
            TopicSpeakers = new HashSet<TopicSpeaker>();
        }

        public int SpeakerId { get; set; }
        public string SpeakerImage { get; set; }
        public string SpeakerName { get; set; }
        public string SpeakerDesignation { get; set; }
        public string SpeakerBio { get; set; }

        public virtual ICollection<TopicSpeaker> TopicSpeakers { get; set; }
    }
}
