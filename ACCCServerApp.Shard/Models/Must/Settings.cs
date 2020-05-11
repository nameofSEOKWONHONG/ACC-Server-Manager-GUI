using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACCServerApp.Shard.Models
{
    public class Settings
    {
        public string ServerName { get; set; } = "ACC SERVER DEFAULT";
        public string AdminPassword { get; set; } = "";
        public int TrackMedalsRequirement { get; set; } = -1;
        public int SafetyRatingRequirement { get; set; } = 60;
        public int RacecraftRatingRequirement { get; set; } = -1;
        public string Password { get; set; } = "";
        public string SpectatorPassword { get; set; } = "";
        public int MaxCarSlots { get; set; } = 80;
        public int DumpLeaderboards { get; set; } = 1;
        public int IsRaceLocked { get; set; } = 1;
        public int RandomizeTrackWhenEmpty { get; set; } = 0;
        public string CentralEntryListPath { get; set; } = "";
        public int AllowAutoDQ { get; set; } = 1;
        public int ShortFormationLap { get; set; } = 1;
        public string DumpEntryList { get; set; } = "";
        public int FormationLapType { get; set; } = 0;

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
