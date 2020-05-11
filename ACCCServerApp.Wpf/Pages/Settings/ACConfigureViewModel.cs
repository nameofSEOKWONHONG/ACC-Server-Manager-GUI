using ACCServerApp.Shard.Utils;
using ACCServerApp.Wpf.Core;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ACCServerApp.Wpf.Pages
{
    public class ACConfigureViewModel : ViewModelBase, IDataErrorInfo, IDisposable
    {
        public ICommand PortCheckCommand { get; }

        public string Error => string.Empty;

        public string this[string columnName]
        {
            get
            {
                return null;
            }
        }

        private readonly IDialogCoordinator _dialogCoordinator;

        public ACCServerApp.Shard.Models.Configuration Configuration { get; set; } = new Shard.Models.Configuration();

        public ACConfigureViewModel(IDialogCoordinator dialogCoordinator)
        {
            this.Configuration = new Shard.Models.Configuration();
            this._dialogCoordinator = dialogCoordinator;

            this.PortCheckCommand = new SimpleCommand(
                o => true,
                async x =>
                {
                    if (x is TextBox textBox)
                    {
                        var number = 0;
                        int.TryParse(textBox.Text, out number);

                        var ctrlName = textBox.Name;

                        if (number <= 0)
                        {
                            await ((MetroWindow)Application.Current.MainWindow).ShowMessageAsync("Error", $"not allow 1 number under.").ConfigureAwait(false);
                            return;
                        }

                        var isUse = NetworkHelper.IsTcpPortAvailable(number);
                        if (isUse)
                        {
                            await ((MetroWindow)Application.Current.MainWindow).ShowMessageAsync($"use available port", number.ToString()).ConfigureAwait(false);
                        }
                        else
                        {
                            await ((MetroWindow)Application.Current.MainWindow).ShowMessageAsync($"used port, select other port.", number.ToString()).ConfigureAwait(false);
                            return;
                        }
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
