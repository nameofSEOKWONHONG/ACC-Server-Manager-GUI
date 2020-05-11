﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ACCServerApp.Shard.Models
{
    public partial class RaceTrack
    {
        public string Value { get; set; }
        public int UniquePitBoxes { get; set; }
        public int PrivateServerSlots { get; set; }
    }

    public partial class RaceTrack
    {
        public string ImagePath { get; set; }
    }
}
