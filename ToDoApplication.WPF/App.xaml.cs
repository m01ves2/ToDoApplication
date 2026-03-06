using System.Windows;
using ToDoApplication.CompositionRoot;

namespace ToDoApplication.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var window = new MainWindow();
            var mainViewModel = AppBuilder.BuildViewModel();
            window.DataContext = mainViewModel;
            window.Show();
        }

    }
}
