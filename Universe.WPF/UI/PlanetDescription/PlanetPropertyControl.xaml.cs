﻿using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Input;

namespace Universe.WPF.UI.PlanetDescription
{
    /// <summary>
    /// Interaction logic for PlanetPropertyControl.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class PlanetPropertyControl
    {
        public static readonly DependencyProperty DeleteItemProperty = DependencyProperty.Register(nameof(DeleteItem),
            typeof(ICommand), typeof(PlanetPropertyControl), new PropertyMetadata(null));

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(nameof(Value),
            typeof(string), typeof(PlanetPropertyControl), new PropertyMetadata(null, _valueChanged));

        private static void _valueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PlanetPropertyControl control && e.NewValue is string value)
            {
                control.ValueTextBlock.Text = value;
            }
        }

        public PlanetPropertyControl()
        {
            InitializeComponent();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (DeleteItem != null && DeleteItem.CanExecute(null))
            {
                DeleteItem.Execute(null);
            }
        }

        public ICommand DeleteItem
        {
            get => (ICommand) GetValue(DeleteItemProperty);
            set => SetValue(DeleteItemProperty, value);
        }

        public string Value
        {
            get => (string) GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            DeleteButton.Visibility = Visibility.Visible;
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            DeleteButton.Visibility = Visibility.Hidden;
        }
    }
}