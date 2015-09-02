using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SportsFestivalManager.Wpf
{
    public class DataGridIntColumn : DataGridTextColumn
    {
        protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
        {
            (editingElement as TextBox).PreviewTextInput += OnPreviewTextInput;

            return base.PrepareCellForEdit(editingElement, editingEventArgs);
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int dummy;
            if (!int.TryParse(e.Text, out dummy))
                e.Handled = true;
        }
    }
}
