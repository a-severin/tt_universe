using System.Data.SQLite;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using Universe.Model;
using Universe.Model.Sqlite;
using Universe.WPF.UI.Main;

namespace Universe.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

//            var window = new MainWindow(new MainViewModel(new TestDataUniverse(new Model.InMemory.Universe())));
//            var window = new MainWindow(new MainViewModel(new TestDataUniverse(new SqliteUniverse(new SQLiteConnection("DataSource=universe.db").OpenAndReturn()))));
            var window =
                new MainWindow(new MainViewModel(
                    (new SqliteUniverse(new SQLiteConnection("DataSource=universe.db").OpenAndReturn()))));
            MainWindow = window;
            ShutdownMode = ShutdownMode.OnMainWindowClose;
            window.Show();
        }
    }
}