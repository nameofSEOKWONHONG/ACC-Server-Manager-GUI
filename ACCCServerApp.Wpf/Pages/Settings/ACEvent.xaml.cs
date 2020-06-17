using System.Windows.Controls;

namespace ACCServerApp.Wpf.Pages
{
    /// <summary>
    /// ACEvent.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ACEvent : UserControl
    {
        private readonly ACEventViewModel _viewModel;
        public ACEvent()
        {
            _viewModel = ViewModelContainer.Instance.GetInstance<ACEventViewModel>();
            DataContext = _viewModel;
            InitializeComponent();
        }
    }
}
