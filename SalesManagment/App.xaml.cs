using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SalesManagment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Let the application do what it need
            base.OnStartup(e);

            // Initializing all required data in the begining
            var ApplicationShell = ApplicationDirector.Instance;
        }
    }
}
