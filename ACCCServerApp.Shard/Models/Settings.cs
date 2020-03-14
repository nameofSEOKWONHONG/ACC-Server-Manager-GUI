using System;
using System.Collections.Generic;
using System.Text;

namespace ACCCServerApp.Shard.Models
{
    public class Settings
    {
        public string ServerName { get; set; } = "ACC Server (please edit settings.json)";
        public string AdminPassword { get; set; } = "";
        public int TrackMedalsRequirement { get; set; } = -1;
        public int SafetyRatingRequirement { get; set; } = -1;
        public int RacecraftRatingRequirement { get; set; } = -1;
        public string Password { get; set; } = "";
        public int MaxCarSlots { get; set; } = 30;
        public string SpectatorPassword { get; set; } = "";
        public int ConfigVersion { get; set; } = 1;

    }
}
