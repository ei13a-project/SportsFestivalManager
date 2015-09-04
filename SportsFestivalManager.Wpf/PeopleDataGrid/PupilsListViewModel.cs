using SportsFestivalManager.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFestivalManager.Wpf
{
    public class PupilsListViewModel : ViewModel
    {
        public ObservableCollection<PupilDataViewModel> Pupils
        {
            get { return GetValue(() => Pupils); }
        }

        public PupilsListViewModel(IEnumerable<Pupil> pupils = null)
            :this(pupils == null ? null : pupils.Select(pupil => new PupilDataViewModel(pupil)))
        {
        }
        public PupilsListViewModel(IEnumerable<PupilDataViewModel> pupils = null)
        {
            SetValue(() => Pupils, new ObservableCollection<PupilDataViewModel>(pupils ?? new PupilDataViewModel[0]));
        }
    }
}
