using System;
using System.Collections.Generic;
using System.Text;

namespace ACCCServerApp.Shard.Models
{
    public class Sessions
    {
        public int HourOfDay { get; set; } = 6;
        public int DayOfWeekend { get; set; } = 2;
        public int TimeMultiplier { get; set; } = 1;
        public string SessionType { get; set; } = "P";
        public int SessionDurationMinutes { get; set; } = 10;
    }
}
