using CichyStrzalko.AnimeKatalog.BL;
using CichyStrzalko.AnimeKatalog.Core.Project.Core.Configuration;
using CichyStrzalko.AnimeKatalog.Interfaces;
using CichyStrzalko.AnimeKatalog.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace CichyStrzalko.AnimeKatalog.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();

            var configuration = AppConfiguration.Configuration;

            if (configuration == null)
                throw new Exception("Configuration is NULL");

            var bl = new BL.BL(configuration);

            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddSingleton<BL.BL>(bl);
            serviceCollection.AddSingleton<MainViewModel>();
            serviceCollection.AddSingleton<MainWindow>();

            serviceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();

            base.OnStartup(e);
        }

    }

}
