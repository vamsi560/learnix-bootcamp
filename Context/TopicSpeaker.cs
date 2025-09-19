using System;
using System.Collections.Generic;

#nullable disable

namespace AzureBootCamp.Context
{
    public partial class TopicSpeaker
    {
        public int TopicSpeakerId { get; set; }
        public int TopicId { get; set; }
        public int SpeakerId { get; set; }

        public virtual Speaker Speaker { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
