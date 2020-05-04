using System;
using System.Collections.Generic;
using System.Text;

namespace ACCCServerApp.Shard.Models
{
    public partial class TrackList
    {
        public string Value { get; set; }
        public int UniquePitBoxes { get; set; }
        public int PrivateServerSlots { get; set; }
    }

    public partial class TrackList
    {
        public string Image { get; set; }
    }
}
