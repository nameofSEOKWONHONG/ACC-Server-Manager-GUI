using ACCServerApp.Shard;
using ACCServerApp.Shard.Models;
using ACCServerApp.Wpf.Core;
using ACCServerApp.Wpf.Pages;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ACCServerApp.Wpf
{
    public class MainWindowViewModel : ViewModelBase, IDataErrorInfo, IDisposable
    {
        public string this[string columnName]
        {
            get
            {
                return null;
            }
        }

        public string Error => string.Empty;

        private readonly IDialogCoordinator _dialogCoordinator;

        private bool _isChecked = false;

        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }

            set
            {
                _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
            }
        }

        public ICommand ConfigSaveCommand { get; set; }
        public ICommand ConfigLoadCommand { get; set; }


        public MainWindowViewModel(IDialogCoordinator dialogCoordinator)
        {
            this._dialogCoordinator = dialogCoordinator;

            this.ConfigSaveCommand = new SimpleCommand(
                o => true,
                async x =>
                {
                    //var acmainTopViewModel = ViewModelContainer.Instance.GetInstance<ACMainTopViewModel>();
                    //ACCServerConfig config = new ACCServerConfig();
                    //config.Configuration = acmainTopViewModel.SelectedConfiguration;
                    //acmainTopViewModel.SelectedEvent.Sessions = acmainTopViewModel.SelectedRaceSessions.ToList();
                    //config.Event = acmainTopViewModel.SelectedEvent;
                    //config.Settings = acmainTopViewModel.SelectedSettings;

                    //var svrFileMgr = new ACCServerFileManager(config);
                    //svrFileMgr.ConfigSave();
                });

            this.ConfigLoadCommand = new SimpleCommand(
                o => true,
                async x =>
                {
                    var acmainTopViewModel = ViewModelContainer.Instance.GetInstance<ACMainTopViewModel>();
                    ACCServerConfig config = new ACCServerConfig();
                    config.Configuration = acmainTopViewModel.SelectedConfiguration;
                    acmainTopViewModel.SelectedEvent.Sessions = acmainTopViewModel.SelectedRaceSessions.ToList();
                    config.Event = acmainTopViewModel.SelectedEvent;
                    config.Settings = acmainTopViewModel.SelectedSettings;

                    var svrFileMgr = new ACCServerFileManager(config);
                    svrFileMgr.ConfigLoad();
                });
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
