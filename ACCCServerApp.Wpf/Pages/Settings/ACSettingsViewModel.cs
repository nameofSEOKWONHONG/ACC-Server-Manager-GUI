using ACCServerApp.Shard.Models;
using ACCServerApp.Wpf.Core;
using ACCServerApp.Wpf.Core;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ACCServerApp.Wpf.Pages
{
    public class ACSettingsViewModel : ViewModelBase, IDataErrorInfo, IDisposable
    {
        
        public string this[string columnName]
        {
            get { return null; }
        }

        public string Error => string.Empty;

        private readonly IDialogCoordinator _dialogCoordinator;

        public Settings Settings { get; set; } = new Settings();

        public ACSettingsViewModel(IDialogCoordinator dialogCoordinator)
        {
            this._dialogCoordinator = dialogCoordinator;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
