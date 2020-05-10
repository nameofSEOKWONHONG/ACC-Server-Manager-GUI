using ACCCServerApp.Shard;
using ACCCServerApp.Shard.Models;
using ACCCServerApp.Wpf.Core;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
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

        public Configuration SelectedConfiguration { get; set; }

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

        private IEnumerable<RaceSession> _selectedRaceSessions;
        public IEnumerable<RaceSession> SelectedRaceSessions
        {
            get
            {
                return _selectedRaceSessions;
            }
            set
            {
                _selectedRaceSessions = value;
                OnPropertyChanged("SelectedRaceSessions");
            }
        }

        public Settings SelectedSettings { get; set; }

        public bool IsServerStartChecked { get; set; } = false;

        public ICommand ServerStartStopCommand { get; set; }
        public ACMainTopViewModel(IDialogCoordinator dialogCoordinator)
        {
            this._dialogCoordinator = dialogCoordinator;

            this.ServerStartStopCommand = new SimpleCommand(
                o => true,
                async x =>
                {
                    ViewModelContainer.Instance.GetInstance<MainWindowViewModel>().IsChecked = true;
                    var serverContainer = new ACCCServerManagerContainer();
                    if (IsServerStartChecked)
                    {
                        var msg = string.Empty;

                        ACCCServerConfig config = new ACCCServerConfig();
                        this.SelectedEvent.Sessions = this.SelectedRaceSessions.ToList();

                        config.Configuration = this.SelectedConfiguration;
                        config.Event = this.SelectedEvent;                        
                        config.Settings = this.SelectedSettings;

                        var sResult = serverContainer.Start(config);

                        IsServerStartChecked = !sResult.HasError;
                        OnPropertyChanged(nameof(IsServerStartChecked));

                        if (IsServerStartChecked)
                        {
                            await ((MetroWindow)Application.Current.MainWindow).ShowMessageAsync($"Server State", "Start acccServer").ConfigureAwait(false);
                        }
                        else
                        {
                            await ((MetroWindow)Application.Current.MainWindow).ShowMessageAsync($"Server State", sResult.Message).ConfigureAwait(false);
                        }
                    }
                    else
                    {
                        var tResult = serverContainer.Stop(string.Empty);
                        if (!tResult.HasError)
                        {
                            await ((MetroWindow)Application.Current.MainWindow).ShowMessageAsync($"Server State", "Stop acccServer").ConfigureAwait(false);
                        }
                        else
                        {
                            await ((MetroWindow)Application.Current.MainWindow).ShowMessageAsync($"Server State", tResult.Message).ConfigureAwait(false);
                        }
                    }

                    ViewModelContainer.Instance.GetInstance<MainWindowViewModel>().IsChecked = IsServerStartChecked;
                });
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
