using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACCServerApp.Shard.Models
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

        public int PostQualySeconds { get; set; } = 30;

        #region [Experimental, Not Support Yet]
        //public string MetaData { get; set; }
        //public string SimracerWeatherConditions { get; set; }
        //public string IsFixedConditionQualification { get; set; }
        #endregion

        public List<RaceSession> Sessions { get; set; } = new List<RaceSession>();

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
