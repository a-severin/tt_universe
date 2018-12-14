using System.Windows;
using MahApps.Metro.Controls;

namespace Universe.UI.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: MetroWindow
    {
        public MainWindow(MainViewModel mainViewModel)
        {
            DataContext = mainViewModel;
            InitializeComponent();
        }
    }
}
