using ACCCServerApp.Shard;
using ACCCServerApp.Shard.Models;
using ACCCServerApp.Wpf.Core;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
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

        public IEnumerable<TrackList> TrackList { get; set; } = ACCCServerDatum.TrackList;
        public Sessions Session { get; set; } = new Sessions();

        private List<Sessions> _sessions = new List<Sessions>();
        public List<Sessions> Sessions
        {
            get
            {
                return _sessions;
            }
            set
            {
                _sessions = value;
                OnPropertyChanged("Sessions");
            }
        }

        public ICommand TrackDropDownMenuItemCommand { get; set; }

        public ACEventViewModel(IDialogCoordinator dialogCoordinator)
        {
            this._dialogCoordinator = dialogCoordinator;
            this.TrackDropDownMenuItemCommand = new SimpleCommand(
                o => true,
                async x =>
                {
                    if(x != null)
                    {

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
