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
        public ObservableCollection<Pupil> Pupils
        {
            get { return GetValue(() => Pupils); }
        }
        public IEnumerable<DataGridProperty> Properties
        {
            get { return GetValue(() => Properties); }
            private set
            {
                if (SetValue(() => Properties, value))
                    OnPropertyChanged(() => GroupableProperties);
            }
        }
        public IEnumerable<DataGridProperty> GroupableProperties
        {
            get { return Properties.Where(x => x.IsGroupable); }
        }

        public PupilsListViewModel(IEnumerable<Pupil> pupils = null)
        {
            SetValue(() => Pupils, new ObservableCollection<Pupil>(pupils ?? new Pupil[0]));
            
        }
    }
}
