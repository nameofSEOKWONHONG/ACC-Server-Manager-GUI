using ACCCServerApp.Shard;
using ACCCServerApp.Wpf.Core;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace ACCCServerApp.Wpf.Pages
{
    public class ACMainBottomViewModel : ViewModelBase, IDataErrorInfo, IDisposable
    {
        public string this[string columnName]
        {
            get { return null; }
        }

        public string Error => string.Empty;

        private readonly IDialogCoordinator _dialogCoordinator;

        public ICommand ServerStartStopCommand { get; }

        public bool IsServerStartChecked { get; set; }

        public ACMainBottomViewModel(IDialogCoordinator dialogCoordinator)
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

                        var sResult = serverContainer.Start(null);
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
