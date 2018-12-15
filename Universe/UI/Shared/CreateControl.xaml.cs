using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

namespace Universe.UI.Shared
{
    /// <summary>
    /// Interaction logic for CreateControl.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class CreateControl : UserControl
    {
        public static readonly DependencyProperty CreateCommandProperty = DependencyProperty.Register(nameof(CreateCommand), typeof(ICommand), typeof(CreateControl), new PropertyMetadata(null));

        public CreateControl()
        {
            InitializeComponent();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddButton.Visibility = Visibility.Collapsed;
            NameTextBox.Visibility = Visibility.Visible;
            ApplyButton.Visibility = Visibility.Visible;
            CancelButton.Visibility = Visibility.Visible;
        }

        private void ApplyButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddButton.Visibility = Visibility.Visible;
            NameTextBox.Visibility = Visibility.Collapsed;
            ApplyButton.Visibility = Visibility.Collapsed;
            CancelButton.Visibility = Visibility.Collapsed;
            if (CreateCommand != null && CreateCommand.CanExecute(NameTextBox.Text))
            {
                CreateCommand.Execute(NameTextBox.Text);
            }
        }

        public ICommand CreateCommand
        {
            get => (ICommand) GetValue(CreateCommandProperty);
            set => SetValue(CreateCommandProperty, value);
        }

        private void NameTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyButton.IsEnabled = !string.IsNullOrEmpty(NameTextBox.Text);
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddButton.Visibility = Visibility.Visible;
            NameTextBox.Visibility = Visibility.Collapsed;
            ApplyButton.Visibility = Visibility.Collapsed;
            CancelButton.Visibility = Visibility.Collapsed;
            NameTextBox.Text = string.Empty;
        }
    }
}