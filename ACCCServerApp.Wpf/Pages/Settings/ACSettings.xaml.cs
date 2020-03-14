using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Text;
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
    /// ACSettings.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ACSettings : UserControl
    {
        private readonly ACSettingsViewModel _viewModel;
        public ACSettings()
        {
            _viewModel = ViewModelContainer.Instance.GetInstance<ACSettingsViewModel>();
            DataContext = _viewModel;
            InitializeComponent();
        }
    }
}
