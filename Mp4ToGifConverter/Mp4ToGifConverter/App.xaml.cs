using Microsoft.Extensions.DependencyInjection;
using Mp4ToGifConverter.Services;
using Mp4ToGifConverter.Services.Interface;
using Mp4ToGifConverter.ViewModels;
using System.Windows;

namespace Mp4ToGifConverter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ConfigureService(new ServiceCollection());

            Current.MainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            Current.MainWindow.Show();   
        }

        private void ConfigureService(IServiceCollection services)
        {
            ServiceProvider = services
                .AddSingleton<MainWindow>()
                .AddSingleton<MainWindowViewModel>()
                .AddTransient<IFileIOService, FileIOService>()
                .BuildServiceProvider();
        }
    }

}
