using ACCCServerApp.Shard.Models;
using ACCCServerApp.Wpf.Core;
using JDotnetExtension;
using JetBrains.Annotations;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ACCCServerApp.Wpf.Pages
{
    public class ACSessionViewModel : ViewModelBase, IDataErrorInfo, IDisposable
    {

        public string Error => string.Empty;

        public string this[string columnName]
        {
            get
            {
                return null;
            }
        }

        private readonly IDialogCoordinator _dialogCoordinator;

        public List<RaceSession> RaceSessions { get; set; } = new List<RaceSession>(3)
        {
            new RaceSession()
            {
                GroupHeader = Shard.ACCCServerDatum.SESSION_TYPES.PRACETICE.ToString(),
                UseYN = true,
                HourOfDay = 13,
                DayOfWeekend = (int)Shard.ACCCServerDatum.DAY_OF_WEEKEND_TYPES.FRIDAY,
                SessionType = Shard.ACCCServerDatum.SESSION_TYPES.PRACETICE.ToDescription(),
                SessionDurationMinutes = 60,
                TimeMultiplier = 1,
            },
            new RaceSession()
            {
                GroupHeader = Shard.ACCCServerDatum.SESSION_TYPES.QUALIFYING.ToString(),
                UseYN = true,
                HourOfDay = 14,
                DayOfWeekend = (int)Shard.ACCCServerDatum.DAY_OF_WEEKEND_TYPES.SATURDAY,
                SessionType = Shard.ACCCServerDatum.SESSION_TYPES.QUALIFYING.ToDescription(),
                SessionDurationMinutes = 20,
                TimeMultiplier = 1,
            },
            new RaceSession()
            {
                GroupHeader = Shard.ACCCServerDatum.SESSION_TYPES.RACE.ToString(),
                UseYN = true,
                HourOfDay = 14,
                DayOfWeekend = (int)Shard.ACCCServerDatum.DAY_OF_WEEKEND_TYPES.SUNDAY,
                SessionType = Shard.ACCCServerDatum.SESSION_TYPES.RACE.ToDescription(),
                SessionDurationMinutes = 60,
                TimeMultiplier = 1,
            }
        };

        public ACSessionViewModel(IDialogCoordinator dialogCoordinator)
        {
            this.RaceSessions.ForEach(item =>
            {
                item.LanguageResource = this.LanguageResource;
            });
            this._dialogCoordinator = dialogCoordinator;
        }

        public bool SaveRaceSession(RaceSession raceSession)
        {
            this.RaceSessions.Clear();
            var raceSessions = this.RaceSessions.Where(m => m.UseYN == true).ToList();
            RaceSessions.AddRange(raceSessions);
            return true;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
