using ACCCServerApp.Wpf.Core;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public ACSessionViewModel(IDialogCoordinator dialogCoordinator)
        {
            this._dialogCoordinator = dialogCoordinator;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
