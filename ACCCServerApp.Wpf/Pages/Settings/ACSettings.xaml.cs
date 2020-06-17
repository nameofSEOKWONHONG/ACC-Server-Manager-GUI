using System.Windows.Controls;

namespace ACCServerApp.Wpf.Pages
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
