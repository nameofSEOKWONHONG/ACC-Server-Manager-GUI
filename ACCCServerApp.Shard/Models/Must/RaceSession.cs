using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACCCServerApp.Shard.Models
{
    public class RaceSession
    {
        public int HourOfDay { get; set; } = 6;
        public int DayOfWeekend { get; set; } = 2;
        public int TimeMultiplier { get; set; } = 1;
        public string SessionType { get; set; } = "P";
        public int SessionDurationMinutes { get; set; } = 10;

        public class Validator : AbstractValidator<RaceSession>
        {
            public Validator()
            {
                RuleFor(m => m.HourOfDay).GreaterThanOrEqualTo(0).LessThanOrEqualTo(23);
                RuleFor(m => m.DayOfWeekend).GreaterThanOrEqualTo(1).LessThanOrEqualTo(3);
                RuleFor(m => m.TimeMultiplier).GreaterThanOrEqualTo(0).LessThanOrEqualTo(24);
                RuleFor(m => m.SessionType).Must((sessionType) => sessionType == "P" || sessionType == "Q" || sessionType == "R");
                RuleFor(m => m.SessionDurationMinutes).LessThanOrEqualTo(30);
            }
        }
    }
}
