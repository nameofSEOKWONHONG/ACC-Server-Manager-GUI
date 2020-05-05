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

        private RaceTrack _selectedTrack;
        public RaceTrack SelectedTrack {
            get
            {
                return _selectedTrack;
            }
            set
            {
                _selectedTrack = value;
                OnPropertyChanged("SelectedTrack");
            }
        }

        public Event _selectedEvent;
        public Event SelectedEvent { get
            {
                return _selectedEvent;
            }
            set
            {
                _selectedEvent = value;
                OnPropertyChanged("SelectedEvent");
            }
        }

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
