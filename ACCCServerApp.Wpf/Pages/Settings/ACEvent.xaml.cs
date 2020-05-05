using ACCCServerApp.Shard.Models;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ACCCServerApp.Wpf.Pages
{
    /// <summary>
    /// ACEvent.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ACEvent : UserControl
    {
        RaceSession SessionDialogItem { get; set; }
        private readonly ACEventViewModel _viewModel;
        private readonly CustomDialog _dialog = null;
        public ACEvent()
        {
            _viewModel = ViewModelContainer.Instance.GetInstance<ACEventViewModel>();
            DataContext = _viewModel;
            InitializeComponent();

            if (_dialog == null)
            {
                _dialog = new CustomDialog(((MetroWindow)Application.Current.MainWindow).MetroDialogOptions) { Content = this.Resources["SessionDialog"], Title = "This dialog allows arbitrary content." };
            }
        }

        private async void AddSessionClick(object sender, RoutedEventArgs e)
        {
            //var customDialog = new CustomDialog() { Title = "Custom Dialog" };

            ////var dataContext = new CustomDialogExampleContent(instance =>
            ////{
            ////    this._dialogCoordinator.HideMetroDialogAsync(this, customDialog);
            ////    System.Diagnostics.Debug.WriteLine(instance.FirstName);
            ////});
            //customDialog.Content = new SessionDialog();

            //await this._dialogCoordinator.ShowMetroDialogAsync(this, customDialog);

            //await ((MetroWindow)Application.Current.MainWindow).ShowMetroDialogAsync(_dialog);
            //await _viewModel.SessionSaveCommand(null);

        }

        private async void SaveClick(object sender, RoutedEventArgs e)
        {
            this._viewModel.SessionSaveCommand.Execute(_viewModel.Session);
            await ((MetroWindow)Application.Current.MainWindow).HideMetroDialogAsync(_dialog);
        }

        private async void CloseClick(object sender, RoutedEventArgs e)
        {
            await ((MetroWindow)Application.Current.MainWindow).HideMetroDialogAsync(_dialog);
        }
    }
}
