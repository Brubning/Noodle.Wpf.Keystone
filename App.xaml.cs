using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Noodle.Wpf.Keystone.Services;

namespace Noodle.Wpf.Keystone
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            var mainWindow = new MainWindow();
            var mainWindowVm = new MainWindowViewModel(new SessionService());
            mainWindow.DataContext = mainWindowVm;
            mainWindow.ShowDialog();
        }
    }
}
