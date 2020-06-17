using ACCServerApp.Shard;
using ACCServerApp.Wpf.Pages;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

#if __WINDOWS__
#endif

namespace ACCServerApp.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly MainWindowViewModel _viewModel;
        public MainWindow()
        {
            _viewModel = ViewModelContainer.Instance.GetInstance<MainWindowViewModel>();
            DataContext = _viewModel;

            InitializeComponent();

            Closed += (s, e) =>
            {
                var procHandler = new ProcessSimpleHandler();
                procHandler.Stop();
            };
        }

        private void SaveClickEvent(object sender, RoutedEventArgs e)
        {

        }

        private void LoadClickEvent(object sender, RoutedEventArgs e)
        {
#if __WINDOWS__
            //var locate = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            using FolderBrowserDialog dlg = new System.Windows.Forms.FolderBrowserDialog();
            dlg.SelectedPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "containers/");
            var result = dlg.ShowDialog();
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                var path = dlg.SelectedPath;
                System.Windows.Forms.MessageBox.Show(path);
                ACCServerFileManager accFileManager = new ACCServerFileManager();
                var config = accFileManager.ConfigLoad(path);

                var configurationViewModel = ViewModelContainer.Instance.GetInstance<ACConfigureViewModel>();
                configurationViewModel.Configuration = config.Configuration;

                var eventViewModel = ViewModelContainer.Instance.GetInstance<ACEventViewModel>();
                eventViewModel.EventItem = config.Event;

                var sessionViewModel = ViewModelContainer.Instance.GetInstance<ACSessionViewModel>();
                sessionViewModel.RaceSessions = config.Event.Sessions;

                var settingsViewModel = ViewModelContainer.Instance.GetInstance<ACSettingsViewModel>();
                settingsViewModel.Settings = config.Settings;
            }
#endif
        }

        private void AdminCommandClick(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "https://www.acc-wiki.info/wiki/Server_Configuration#Admin_Commands",
                UseShellExecute = true
            };
            Process.Start(psi);
            e.Handled = true;
        }

        private async void ACCInstallPathClick(object sender, RoutedEventArgs e)
        {
            var result = await this.ShowInputAsync("Install File Setting", "Input Your ACC Install Path?", 
                new MetroDialogSettings {DefaultText = ACCServerApp.Wpf.Properties.Settings.Default["ACCInstallPath"].ToString()});

            if (result == null) //user pressed cancel
                return;

            ACCServerApp.Wpf.Properties.Settings.Default["ACCInstallPath"] = result;
            ACCServerApp.Wpf.Properties.Settings.Default.Save();

            await this.ShowMessageAsync("Install Path is ", ACCServerApp.Wpf.Properties.Settings.Default["ACCInstallPath"].ToString());
        }

        private void LanguageClickEvent(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if(menuItem != null)
            {
                var header = menuItem.Header;

                if(header.ToString() == "English")
                {
                    foreach(var viewmodel in ViewModelContainer.Instance.GetInstances())
                    {
                        viewmodel.LanguageResource = LanguageHandler.Instance["en-US"];
                    }

                    ViewModelContainer.Instance.GetInstance<ACSessionViewModel>().RaceSessions.ForEach(item =>
                    {
                        item.LanguageResource = LanguageHandler.Instance["en-US"];
                    });
                }
                else
                {
                    foreach (var viewmodel in ViewModelContainer.Instance.GetInstances())
                    {
                        viewmodel.LanguageResource = LanguageHandler.Instance["ko-KR"];
                    }

                    ViewModelContainer.Instance.GetInstance<ACSessionViewModel>().RaceSessions.ForEach(item =>
                    {
                        item.LanguageResource = LanguageHandler.Instance["ko-KR"];
                    });
                }
            }
        }

    }
}
