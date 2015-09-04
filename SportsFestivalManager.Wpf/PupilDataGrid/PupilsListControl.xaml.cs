using SportsFestivalManager.Data;
using System;
using System.Collections.Generic;
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

namespace SportsFestivalManager.Wpf.PupilDataGrid
{
    /// <summary>
    /// Interaktionslogik für PupilsListControl.xaml
    /// </summary>
    public partial class PupilsListControl : UserControl
    {
        public PupilsListControl()
        {
            InitializeComponent();

            var address = new Address { Location="Location", PostalCode="123", Street="Street", HouseNumber="123" };
            var teacher = new Teacher() { Address = address, BirthDate = DateTime.Now, FirstName = "FirstName", LastName = "LastName" };

            var pupils = new Pupil[10];
            for (int i = 0; i < pupils.Length; i++)
            {
                pupils[i] = new Pupil()
                {
                    Address = address,
                    FirstName = "Hans" + i.ToString(),
                    LastName = "Wurst" + i.ToString(),
                    BirthDate = DateTime.Now.Subtract(TimeSpan.FromDays(10 * 365)),
                    Class = "@"
                };
            }

            DataContext = new PupilsListViewModel(pupils);
        }
    }
}