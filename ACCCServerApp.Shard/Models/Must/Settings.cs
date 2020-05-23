using FluentValidation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ACCServerApp.Shard.Models
{
    public class Settings
    {
        [JsonProperty("serverName")]
        public string ServerName { get; set; } = "ACC_SERVER_DEFAULT";

        [JsonProperty("adminPassword")]
        public string AdminPassword { get; set; } = "administrator";

        [JsonProperty("carGroup")]
        public string CarGroup { get; set; } = "FreeForAll";

        [JsonProperty("trackMedalsRequirement")]
        public int TrackMedalsRequirement { get; set; } = 0;

        [JsonProperty("safetyRatingRequirement")]
        public int SafetyRatingRequirement { get; set; } = 60;

        [JsonProperty("racecraftRatingRequirement")]
        public int RacecraftRatingRequirement { get; set; } = -1;

        [JsonProperty("password")]
        public string Password { get; set; } = "guest";

        [JsonProperty("spectatorPassword")]
        public string SpectatorPassword { get; set; } = "guestview";

        //[JsonProperty("maxCarSlots")]
        //public int MaxCarSlots { get; set; } = 80;

        [JsonProperty("dumpLeaderboards")]
        public int DumpLeaderboards { get; set; } = 1;

        [JsonProperty("dumpEntryList")]
        public int DumpEntryList { get; set; } = 0;

        [JsonProperty("isRaceLocked")]
        public int IsRaceLocked { get; set; } = 1;

        [JsonProperty("shortFormationLap")]
        public int ShortFormationLap { get; set; } = 1;

        [JsonProperty("formationLapType")]
        public int FormationLapType { get; set; } = 0;

        [JsonProperty("doDriverSwapBroadcast")]
        public int DoDriverSwapBroadcast { get; set; } = 1;

        [JsonProperty("randomizeTrackWhenEmpty")]
        public int RandomizeTrackWhenEmpty { get; set; } = 0;

        [JsonProperty("centralEntryListPath")]
        public string CentralEntryListPath { get; set; } = "";

        //[JsonProperty("allowAutoDQ")]
        //public int AllowAutoDQ { get; set; } = 1;

        [JsonProperty("configVersion")]
        public int ConfigVersion { get; set; } = 1;



        public class Validator : AbstractValidator<Settings>
        {
            public Validator()
            {
                RuleFor(m => m.ServerName).NotEmpty();
                RuleFor(m => m.AdminPassword).NotEmpty();
                RuleFor(m => m.TrackMedalsRequirement).GreaterThanOrEqualTo(0).LessThanOrEqualTo(3);
                RuleFor(m => m.SafetyRatingRequirement).GreaterThanOrEqualTo(-1).LessThanOrEqualTo(99);
                RuleFor(m => m.RacecraftRatingRequirement).GreaterThanOrEqualTo(-1).LessThanOrEqualTo(99);
                RuleFor(m => m.Password).NotEmpty()
                                        .NotEqual(m => m.AdminPassword)
                                        .NotEqual(m => m.SpectatorPassword);
                RuleFor(m => m.SpectatorPassword).NotEmpty()
                                                 .NotEqual(m => m.AdminPassword)
                                                 .NotEqual(m => m.Password);
                //RuleFor(m => m.MaxCarSlots).GreaterThanOrEqualTo(0);
                RuleFor(m => m.IsRaceLocked).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
                RuleFor(m => m.RandomizeTrackWhenEmpty).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
                //RuleFor(m => m.AllowAutoDQ).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
                RuleFor(m => m.ShortFormationLap).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
                RuleFor(m => m.FormationLapType).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
            }
        }
    }
}
