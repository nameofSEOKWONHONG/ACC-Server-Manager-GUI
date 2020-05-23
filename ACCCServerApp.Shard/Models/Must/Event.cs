using FluentValidation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACCServerApp.Shard.Models
{
    public class Event
    {
        [JsonProperty("track")]
        public string Tracks { get; set; } = "mount_panorama_2019";

        [JsonProperty("eventType")]
        public string EventType { get; set; } = "E_6h";

        [JsonProperty("preRaceWaitingTimeSeconds")]
        public int PreRaceWaitingTimeSeconds { get; set; } = 80;

        [JsonProperty("postQualySeconds")]
        public int PostQualySeconds { get; set; } = 30;

        [JsonProperty("postRaceSeconds")] 
        public int PostRaceSeconds { get; set; } = 15;

        [JsonProperty("sessionOverTimeSeconds")]
        public int SessionOverTimeSeconds { get; set; } = 120;

        [JsonProperty("ambientTemp")]
        public int AmbientTemp { get; set; } = 22;

        [JsonProperty("trackTemp")]
        public int trackTemp { get; set; } = 26;

        [JsonProperty("cloudLevel")]
        public double CloudLevel { get; set; } = 0.1;

        [JsonProperty("rain")]
        public double Rain { get; set; } = 0.0;

        [JsonProperty("weatherRandomness")]
        public int WeatherRandomness { get; set; } = 1;

        #region [Experimental, Not Support Yet]
        //public string MetaData { get; set; }
        //public string SimracerWeatherConditions { get; set; }
        //public string IsFixedConditionQualification { get; set; }
        #endregion

        [JsonProperty("sessions")]
        public List<RaceSession> Sessions { get; set; } = new List<RaceSession>();

        [JsonProperty("configVersion")]
        public int ConfigVersion { get; set; } = 1;

        public class Validator : AbstractValidator<Event>
        {
            public Validator()
            {
                RuleFor(m => m.Tracks).NotEmpty();
                RuleFor(m => m.PreRaceWaitingTimeSeconds).LessThan(80);
                RuleFor(m => m.SessionOverTimeSeconds).LessThan(120);
                RuleFor(m => m.AmbientTemp).GreaterThan(0);
                RuleFor(m => m.CloudLevel).GreaterThanOrEqualTo(0.0).LessThanOrEqualTo(1.0);
                RuleFor(m => m.Rain).GreaterThanOrEqualTo(0.0).LessThanOrEqualTo(1.0);
                RuleFor(m => m.WeatherRandomness).GreaterThanOrEqualTo(0).LessThanOrEqualTo(7);
                RuleFor(m => m.PostQualySeconds).GreaterThanOrEqualTo(0).LessThanOrEqualTo(120);

            }
        }
    }
}
