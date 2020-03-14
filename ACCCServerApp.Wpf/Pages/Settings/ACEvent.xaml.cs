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
            await ((MetroWindow)Application.Current.MainWindow).ShowMetroDialogAsync(_dialog);

            //var textBlock = dialog.FindChild<TextBlock>("MessageTextBlock");
            //textBlock.Text = "A message box will appear in 3 seconds.";

            //await Task.Delay(3000);

            //await ((MetroWindow)Application.Current.MainWindow).ShowMessageAsync("Secondary dialog", "This message is shown on top of another.", MessageDialogStyle.Affirmative, new MetroDialogSettings() { OwnerCanCloseWithDialog = true, ColorScheme = ((MetroWindow)Application.Current.MainWindow).MetroDialogOptions.ColorScheme });

            //textBlock.Text = "The dialog will close in 2 seconds.";
            //await Task.Delay(2000);

            //await ((MetroWindow)Application.Current.MainWindow).HideMetroDialogAsync(_dialog);
        }

        private async void SaveClick(object sender, RoutedEventArgs e)
        {
            _viewModel.Sessions.Add(new Shard.Models.Sessions()
            {
                DayOfWeekend = 0,
                HourOfDay = 0,
                SessionDurationMinutes = 0,
                SessionType = "P",
                TimeMultiplier = 1
            });

            await ((MetroWindow)Application.Current.MainWindow).HideMetroDialogAsync(_dialog);
        }

        private async void CloseClick(object sender, RoutedEventArgs e)
        {
            await ((MetroWindow)Application.Current.MainWindow).HideMetroDialogAsync(_dialog);
        }
    }
}
