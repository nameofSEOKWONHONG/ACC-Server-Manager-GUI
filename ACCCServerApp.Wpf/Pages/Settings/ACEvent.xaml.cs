using ACCServerApp.Shard.Models;
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

namespace ACCServerApp.Wpf.Pages
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
    }
}
