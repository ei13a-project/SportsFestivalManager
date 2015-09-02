using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsFestivalManager.Wpf
{
    public interface IView<TViewModel>
        where TViewModel : ViewModel
    {
        TViewModel ViewModel { get; set; }
    }
}
