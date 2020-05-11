using System;
using System.Collections.Generic;
using System.Text;

namespace ACCServerApp.Shard.Models
{
    public class AssistRules
    {
        public int DisableIdealLine { get; set; } = 0;
        public int DisableAutosteer { get; set; } = 0;
        public int StabilityControlLevelMax { get; set; } = 100;
        public int DisableAutoPitLimiter { get; set; } = 0;
        public int DisableAutoGear { get; set; } = 0;
        public int DisableAutoClutch { get; set; } = 0;
        public int DisableAutoEngineStart { get; set; } = 0;
        public int DisableAutoWiper { get; set; } = 0;
        public int DisableAutoLights { get; set; } = 0;
    }
}
