﻿using ACCCServerApp.Wpf.Language;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ACCCServerApp.Wpf
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

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
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
                }
                else
                {
                    foreach (var viewmodel in ViewModelContainer.Instance.GetInstances())
                    {
                        viewmodel.LanguageResource = LanguageHandler.Instance["ko-KR"];
                    }
                }
            }
        }
    }
}