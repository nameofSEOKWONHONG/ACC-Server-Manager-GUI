using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
    /// ACConfiguration.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ACConfiguration : UserControl
    {
        private readonly ACConfigureViewModel _viewModel;
        public ACConfiguration()
        {
            _viewModel = ViewModelContainer.Instance.GetInstance<ACConfigureViewModel>();
            DataContext = _viewModel;

            InitializeComponent();
        }
    }
}
