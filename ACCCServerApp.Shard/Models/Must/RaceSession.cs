using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

using JDotnetExtension;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ACCServerApp.Shard.Models
{
    public partial class RaceSession
    {
        [JsonProperty("hourOfDay")]
        public int HourOfDay { get; set; } = 6;

        [JsonProperty("dayOfWeekend")]
        public int DayOfWeekend { get; set; } = 2;

        [JsonProperty("timeMultiplier")]
        public int TimeMultiplier { get; set; } = 1;

        [JsonProperty("sessionType")]
        public string SessionType { get; set; }

        [JsonProperty("sessionDurationMinutes")]
        public int SessionDurationMinutes { get; set; } = 10;

        public class Validator : AbstractValidator<RaceSession>
        {
            public Validator()
            {
                RuleFor(m => m.HourOfDay).GreaterThanOrEqualTo(0).LessThanOrEqualTo(23);
                RuleFor(m => m.DayOfWeekend).GreaterThanOrEqualTo(1).LessThanOrEqualTo(3);
                RuleFor(m => m.TimeMultiplier).GreaterThanOrEqualTo(0).LessThanOrEqualTo(24);
                RuleFor(m => m.SessionType).Must((sessionType) => sessionType == ACCServerDatum.SESSION_TYPES.PRACETICE.ToDescription() || 
                                                                  sessionType == ACCServerDatum.SESSION_TYPES.QUALIFYING.ToDescription() || 
                                                                  sessionType == ACCServerDatum.SESSION_TYPES.RACE.ToDescription());
                RuleFor(m => m.SessionDurationMinutes).LessThanOrEqualTo(30);
            }
        }
    }

    public partial class RaceSession
    {
        [Newtonsoft.Json.JsonIgnore]
        public string GroupHeader { get; set; }
        /// <summary>
        /// 세션 사용여부
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public bool UseYN { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public LanguageResource LanguageResource { get; set; }
    }
}
