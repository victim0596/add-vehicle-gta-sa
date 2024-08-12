using addVehicle.generatorLine.Concrete;
using addVehicle.generatorLine.Contract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace addVehicle
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider _serviceProvider { get; private set; }
        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        public void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IGenfxt, Genfxt>();
            services.AddScoped<IGenLineeOnLimitAdjuster, GenLineeOnLimitAdjuster>();
            services.AddScoped<IGenMod, GenModFile>();
            services.AddScoped<IMergeLine, MergeLine>();
            services.AddScoped<ISaveFile, SaveFile>();
            services.AddScoped<IMainGenerator, MainGenerator>();
            services.AddScoped<IGenLineLoader, GenLineLoader>();

            services.AddScoped<MainWindow>();
        }
    }
}
