using System;
using System.Collections.Generic;
using System.Text;

namespace ACCCServerApp.Shard.Models
{
    public class Event
    {
        public string Tracks { get; set; } = "mount_panorama_2019";
        public int PreRaceWaitingTimeSeconds { get; set; } = 80;
        public int SessionOverTimeSeconds { get; set; } = 120;

        public int AmbientTemp { get; set; } = 22;

        public double CloudLevel { get; set; } = 0.1;
        public double Rain { get; set; } = 0.0;

        public int WeatherRandomness { get; set; } = 1;

        public List<Sessions> Sessions { get; set; } = new List<Sessions>();

        public int ConfigVersion { get; set; } = 1;
    }
}
