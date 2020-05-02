using ACCCServerApp.Wpf.Core;
using ACCCServerApp.Wpf.Pages;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACCCServerApp.Wpf
{
    public class ViewModelContainer
    {
        private static readonly Lazy<ViewModelContainer> _instance =
          new Lazy<ViewModelContainer>(() => new ViewModelContainer());

        public static ViewModelContainer Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private readonly IEnumerable<ViewModelBase> _viewModels = new List<ViewModelBase>()
        {
            new MainWindowViewModel(DialogCoordinator.Instance),
            new ACMainBottomViewModel(DialogCoordinator.Instance),
            new ACConfigureViewModel(DialogCoordinator.Instance),
            new ACEventViewModel(DialogCoordinator.Instance),
            new ACSettingsViewModel(DialogCoordinator.Instance),
        };

        public TViewModel GetInstance<TViewModel>() where TViewModel : class
        {
            return _viewModels.Where(m => m.GetType() == typeof(TViewModel)).First() as TViewModel;
        }

        public IEnumerable<ViewModelBase> GetInstances()
        {
            return _viewModels;
        }

        private ViewModelContainer()
        {

        }
    }
}
