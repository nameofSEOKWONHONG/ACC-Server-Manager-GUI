using System;
using System.Collections.Generic;
using System.Text;

namespace ACCCServerApp.Shard.Models
{
    public class ACCCServerConfig
    {
        public Configuration Configuration { get; set; }
        public Event Event { get; set; }
        public Settings Settings { get; set; }

        public AssistRules AssistRules { get; set; }

    }

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
