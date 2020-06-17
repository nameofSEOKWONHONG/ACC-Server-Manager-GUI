using System.Windows.Controls;

namespace ACCServerApp.Wpf.Pages
{
    /// <summary>
    /// ACSession.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ACSession : UserControl
    {

        private readonly ACSessionViewModel _viewModel;
        public ACSession()
        {
            _viewModel = ViewModelContainer.Instance.GetInstance<ACSessionViewModel>();
            DataContext = _viewModel;
            InitializeComponent();
        }
    }
}
