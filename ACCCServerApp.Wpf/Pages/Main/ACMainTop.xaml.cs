using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ACCCServerApp.Wpf.Pages
{
    /// <summary>
    /// ACMainTop.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ACMainTop : UserControl
    {
        ACMainTopViewModel _viewModel;
        public ACMainTop()
        {
            _viewModel = ViewModelContainer.Instance.GetInstance<ACMainTopViewModel>();
            _viewModel.SelectedEvent = ViewModelContainer.Instance.GetInstance<ACEventViewModel>().EventItem;
            DataContext = _viewModel;
            InitializeComponent();

            Loaded += ACMainTop_Loaded;
        }

        private void ACMainTop_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
