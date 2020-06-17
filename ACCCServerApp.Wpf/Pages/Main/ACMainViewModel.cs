using ACCServerApp.Shard;
using ACCServerApp.Shard.Models;
using ACCServerApp.Wpf.Core;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace ACCServerApp.Wpf.Pages
{
    public class ACMainViewModel : ViewModelBase, IDataErrorInfo, IDisposable
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

        public ACMainViewModel(IDialogCoordinator dialogCoordinator)
        {
            this._dialogCoordinator = dialogCoordinator;           

            this.ServerStartStopCommand = new SimpleCommand(
                o => true,
                async x =>
                {
                    ViewModelContainer.Instance.GetInstance<MainWindowViewModel>().IsChecked = true;
                    var serverContainer = new ACCServerManagerContainer();
                    if (IsServerStartChecked)
                    {
                        var msg = string.Empty;

                        ACCServerConfig config = new ACCServerConfig();
                        this.SelectedEvent.Sessions = ViewModelContainer.Instance.GetInstance<ACSessionViewModel>().RaceSessions;

                        config.Configuration = ViewModelContainer.Instance.GetInstance<ACConfigureViewModel>().Configuration;
                        config.Event = ViewModelContainer.Instance.GetInstance<ACEventViewModel>().EventItem;                        
                        config.Settings = ViewModelContainer.Instance.GetInstance<ACSettingsViewModel>().Settings;
                        config.ServerFilePath = ACCServerApp.Wpf.Properties.Settings.Default["ACCInstallPath"].ToString();

                        ACCServerConfig.Validator validator = new ACCServerConfig.Validator();
                        var validateResult = validator.Validate(config);
                        if(!validateResult.IsValid)
                        {
                            IsServerStartChecked = false;
                            OnPropertyChanged(nameof(IsServerStartChecked));
                            ViewModelContainer.Instance.GetInstance<MainWindowViewModel>().IsChecked = IsServerStartChecked;
                            await ((MetroWindow)Application.Current.MainWindow).ShowMessageAsync($"Validator Error", validateResult.Errors[0].ErrorMessage).ConfigureAwait(false);
                            return;
                        }

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
                        var serverName = ViewModelContainer.Instance.GetInstance<ACSettingsViewModel>().Settings.ServerName;
                        var tResult = serverContainer.Stop(serverName);
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

            System.Timers.Timer timer = new System.Timers.Timer(2000);
            timer.Elapsed += (s, e) =>
            {
                this.SelectedConfiguration = ViewModelContainer.Instance.GetInstance<ACConfigureViewModel>().Configuration;
                this.SelectedEvent = ViewModelContainer.Instance.GetInstance<ACEventViewModel>().EventItem;
                this.SelectedSettings = ViewModelContainer.Instance.GetInstance<ACSettingsViewModel>().Settings;
            };
            timer.Start();            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
