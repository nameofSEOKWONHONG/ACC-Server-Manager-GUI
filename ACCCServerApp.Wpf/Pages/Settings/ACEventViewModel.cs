using ACCCServerApp.Shard;
using ACCCServerApp.Shard.Models;
using ACCCServerApp.Wpf.Core;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace ACCCServerApp.Wpf.Pages
{
    public class ACEventViewModel : ViewModelBase, IDataErrorInfo, IDisposable
    {
        public string this[string columnName]
        {
            get { return null; }
        }

        public string Error => string.Empty;

        private readonly IDialogCoordinator _dialogCoordinator;

        #region [readonly itemsource]
        public IEnumerable<RaceTrack> TrackList { get; } = ACCCServerDatum.TrackList;
        public IEnumerable<KeyValueSimpleModel> DayOfWeekens { get; } = ACCCServerDatum.DayOfWeeken;
        public IEnumerable<KeyValueSimpleModel> SessionTypes { get; } = ACCCServerDatum.SessionType;
        #endregion

        public RaceTrack SelectedTrack { get; set; }
        public RaceSession Session { get; set; } = new RaceSession();

        public Event EventItem { get; set; } = new Event();

        private List<RaceSession> _sessions = new List<RaceSession>();
        public List<RaceSession> Sessions
        {
            get
            {
                return EventItem.Sessions;
            }
            set
            {
                EventItem.Sessions = value;
                OnPropertyChanged("Sessions");
            }
        }

        public ICommand TrackDropDownMenuItemCommand { get; set; }
        public ICommand SessionSaveCommand { get; set; }

        public ACEventViewModel(IDialogCoordinator dialogCoordinator)
        {
            this._dialogCoordinator = dialogCoordinator;
            this.TrackDropDownMenuItemCommand = new SimpleCommand(
                o => true,
                async x =>
                {
                    if(x != null)
                    {
                        SelectedTrack = x as RaceTrack;
                        ViewModelContainer.Instance.GetInstance<ACMainTopViewModel>().SelectedTrack = this.SelectedTrack;
                    }
                }
            );
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
