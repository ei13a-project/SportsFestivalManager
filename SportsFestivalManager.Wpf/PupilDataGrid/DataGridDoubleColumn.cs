using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SportsFestivalManager.Wpf.PupilDataGrid
{
    public class DataGridDoubleColumn : DataGridTextColumn
    {
        protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
        {
            (editingElement as TextBox).PreviewTextInput += OnPreviewTextInput;

            return base.PrepareCellForEdit(editingElement, editingEventArgs);
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            double dummy;
            if (!double.TryParse(e.Text, out dummy))
                e.Handled = true;
        }
    }
}
