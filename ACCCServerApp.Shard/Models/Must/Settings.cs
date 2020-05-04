using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACCCServerApp.Shard.Models
{
    public class Settings
    {
        public string ServerName { get; set; }
        public string AdminPassword { get; set; }
        public int TrackMedalsRequirement { get; set; }
        public int SafetyRatingRequirement { get; set; }
        public int RacecraftRatingRequirement { get; set; }
        public string Password { get; set; }
        public string SpectatorPassword { get; set; }
        public int MaxCarSlots { get; set; }
        public int DumpLeaderboards { get; set; }
        public int IsRaceLocked { get; set; }
        public int RandomizeTrackWhenEmpty { get; set; }
        public string CentralEntryListPath { get; set; }
        public int AllowAutoDQ { get; set; }
        public int ShortFormationLap { get; set; }
        public string DumpEntryList { get; set; }
        public int FormationLapType { get; set; }

        public class Validator : AbstractValidator<Settings>
        {
            public Validator()
            {
                RuleFor(m => m.ServerName).NotEmpty();
                RuleFor(m => m.AdminPassword).NotEmpty();
                RuleFor(m => m.TrackMedalsRequirement).GreaterThanOrEqualTo(-1).LessThanOrEqualTo(3);
                RuleFor(m => m.SafetyRatingRequirement).GreaterThanOrEqualTo(-1).LessThanOrEqualTo(99);
                RuleFor(m => m.RacecraftRatingRequirement).GreaterThanOrEqualTo(-1).LessThanOrEqualTo(99);
                RuleFor(m => m.Password).NotEmpty()
                                        .NotEqual(m => m.AdminPassword)
                                        .NotEqual(m => m.SpectatorPassword);
                RuleFor(m => m.SpectatorPassword).NotEmpty()
                                                 .NotEqual(m => m.AdminPassword)
                                                 .NotEqual(m => m.Password);
                RuleFor(m => m.MaxCarSlots).GreaterThanOrEqualTo(0);
                RuleFor(m => m.IsRaceLocked).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
                RuleFor(m => m.RandomizeTrackWhenEmpty).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
                RuleFor(m => m.AllowAutoDQ).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
                RuleFor(m => m.ShortFormationLap).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
                RuleFor(m => m.FormationLapType).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
            }
        }
    }
}
