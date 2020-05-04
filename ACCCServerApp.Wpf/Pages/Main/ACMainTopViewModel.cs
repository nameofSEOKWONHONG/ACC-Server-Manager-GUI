using ACCCServerApp.Shard;
using ACCCServerApp.Shard.Models;
using ACCCServerApp.Wpf.Core;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ACCCServerApp.Wpf.Pages
{
    public class ACMainTopViewModel : ViewModelBase, IDataErrorInfo, IDisposable
    {
        public string this[string columnName]
        {
            get { return null; }
        }

        public string Error => string.Empty;

        private readonly IDialogCoordinator _dialogCoordinator;

        public TrackList SelectedTrack { get; set; } = ACCCServerDatum.TrackList.ToList()[0];
        public Event SelectedEvent { get; set; } = new Event
        {
            AmbientTemp = 25,
            Sessions = new List<Sessions>()
            {
                new Sessions(){DayOfWeekend = 1, HourOfDay = 6, SessionDurationMinutes = 10, SessionType = "P", TimeMultiplier = 1},
                new Sessions(){DayOfWeekend = 1, HourOfDay = 6, SessionDurationMinutes = 10, SessionType = "Q", TimeMultiplier = 1},
                new Sessions(){DayOfWeekend = 1, HourOfDay = 6, SessionDurationMinutes = 10, SessionType = "R", TimeMultiplier = 1},
            }
        };

        public ACMainTopViewModel(IDialogCoordinator dialogCoordinator)
        {
            this._dialogCoordinator = dialogCoordinator;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
