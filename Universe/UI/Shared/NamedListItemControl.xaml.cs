using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Universe.UI.Shared
{
    /// <summary>
    ///     Interaction logic for NamedListItemControl.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class NamedListItemControl : UserControl
    {
        public static readonly DependencyProperty ItemNameProperty = DependencyProperty.Register(nameof(ItemName),
            typeof(string), typeof(NamedListItemControl), new PropertyMetadata(null, _itemNameChanged));

        public static readonly DependencyProperty EditItemNameProperty =
            DependencyProperty.Register(nameof(EditItemName), typeof(ICommand), typeof(NamedListItemControl),
                new PropertyMetadata(null));

        public static readonly DependencyProperty DeleteItemProperty = DependencyProperty.Register(nameof(DeleteItem),
            typeof(ICommand), typeof(NamedListItemControl), new PropertyMetadata(null));

        public NamedListItemControl()
        {
            InitializeComponent();
        }

        public ICommand DeleteItem
        {
            get => (ICommand) GetValue(DeleteItemProperty);
            set => SetValue(DeleteItemProperty, value);
        }

        public ICommand EditItemName
        {
            get => (ICommand) GetValue(EditItemNameProperty);
            set => SetValue(EditItemNameProperty, value);
        }

        public string ItemName
        {
            get => (string) GetValue(ItemNameProperty);
            set => SetValue(ItemNameProperty, value);
        }

        private void CancelEditButton_OnClick(object sender, RoutedEventArgs e)
        {
            EditControl.Visibility = Visibility.Collapsed;
            DisplayControl.Visibility = Visibility.Visible;
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            EditControl.Visibility = Visibility.Visible;
            DisplayControl.Visibility = Visibility.Collapsed;
            EditNameTextBox.Text = ItemName;
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            EditButtonsPanel.Visibility = Visibility.Visible;
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);

            EditButtonsPanel.Visibility = Visibility.Hidden;
        }

        private static void _itemNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is NamedListItemControl control && e.NewValue is string value) control.NameTextBlock.Text = value;
        }

        private void ApplyEditButton_OnClick(object sender, RoutedEventArgs e)
        {
            var name = EditNameTextBox.Text;
            if (EditItemName != null && EditItemName.CanExecute(name))
            {
                EditItemName?.Execute(name);
            }

            EditControl.Visibility = Visibility.Collapsed;
            DisplayControl.Visibility = Visibility.Visible;
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (DeleteItem != null && DeleteItem.CanExecute(null))
            {
                DeleteItem.Execute(null);
            }
        }
    }
}