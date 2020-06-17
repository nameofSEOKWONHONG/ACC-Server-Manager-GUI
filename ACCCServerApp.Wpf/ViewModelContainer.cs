﻿using ACCServerApp.Wpf.Core;
using ACCServerApp.Wpf.Pages;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCServerApp.Wpf
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

            new ACMainViewModel(DialogCoordinator.Instance),

            new ACConfigureViewModel(DialogCoordinator.Instance),
            new ACEventViewModel(DialogCoordinator.Instance),
            new ACSessionViewModel(DialogCoordinator.Instance),
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
