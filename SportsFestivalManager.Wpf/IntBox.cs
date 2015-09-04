using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SportsFestivalManager.Wpf
{
    public class IntBox : TextBox
    {
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            int dummy;
            if (!int.TryParse(e.Text, out dummy))
                e.Handled = true;
        }
    }
}
