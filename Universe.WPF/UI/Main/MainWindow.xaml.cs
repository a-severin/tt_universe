using System.Diagnostics.CodeAnalysis;
using MahApps.Metro.Controls;

namespace Universe.WPF.UI.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class MainWindow: MetroWindow
    {
        public MainWindow(MainViewModel mainViewModel)
        {
            DataContext = mainViewModel;
            InitializeComponent();
        }
    }
}
