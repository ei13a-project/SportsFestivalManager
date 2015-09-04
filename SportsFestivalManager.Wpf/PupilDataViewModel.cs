using SportsFestivalManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportsFestivalManager.Wpf
{
    public class PupilDataViewModel : PersonDataViewModel
    {
        private Pupil _pupil;

        public PupilDataViewModel(Pupil pupil = null)
            : base(pupil = pupil ?? new Pupil())
        {
            _pupil = pupil;
        }
    }
}