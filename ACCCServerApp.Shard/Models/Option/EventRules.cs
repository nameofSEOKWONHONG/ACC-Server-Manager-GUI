using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ACCServerApp.Shard.Models.Option
{
    public class EventRules
    {
        public int QualifyStandingType { get; set; } = 1;
        public int SuperpoleMaxCar { get; set; } = -1;
        public int PitWindowLengthSec { get; set; } = -1;
        public int DriverStintTimeSec { get; set; } = -1;
        public bool IsRefuellingAllowedInRace { get; set; } = false;
        public bool IsRefuellingTimeFixed { get; set; } = false;
        public int MandatoryPitstopCount { get; set; }
        public int MaxTotalDrivingTime { get; set; }
        public int MaxDriversCount { get; set; }
        public bool IsMandatoryPitstopRefuellingRequired { get; set; } = false;
        public bool IsMandatoryPitstopTyreChangeRequired { get; set; } = false;
        public bool IsMandatoryPitstopSwapDriverRequired { get; set; } = false;
        public int TyreSetCount { get; set; }

        public class Validator : AbstractValidator<EventRules>
        {
            public Validator()
            {
                RuleFor(m => m.QualifyStandingType).InclusiveBetween(1, 2).Equal(2).WithErrorCode("not support yet, 2");
                RuleFor(m => m.SuperpoleMaxCar).Equal(-1).WithMessage("not support yet other number");
                RuleFor(m => m.PitWindowLengthSec).InclusiveBetween(-1, 600);
                RuleFor(m => m.DriverStintTimeSec).InclusiveBetween(-1, 3300);
                RuleFor(m => m.TyreSetCount).InclusiveBetween(1, 50);
                
            }
        }

    }
}
