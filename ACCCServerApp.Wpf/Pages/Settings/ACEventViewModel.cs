using ACCServerApp.Shard;
using ACCServerApp.Shard.Models;
using ACCServerApp.Wpf.Core;
using JDotnetExtension;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace ACCServerApp.Wpf.Pages
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
        public IEnumerable<RaceTrack> TrackList { get; } = ACCServerDatum.TrackList;
        public IEnumerable<KeyValueSimpleModel> DayOfWeekens { get; } = ACCServerDatum.DayOfWeeken;
        public IEnumerable<KeyValueSimpleModel> SessionTypes { get; } = ACCServerDatum.SessionType;
        #endregion

        public RaceTrack SelectedTrack { get; set; } = ACCServerDatum.TrackList.ToList()[0];

        public Event EventItem { get; set; } = new Event();

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
            System.Timers.Timer timer = new System.Timers.Timer(100);
            timer.Elapsed += (s, e) =>
            {
                ViewModelContainer.Instance.GetInstance<ACMainTopViewModel>().SelectedTrack = this.SelectedTrack;
            };
            timer.Start();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
