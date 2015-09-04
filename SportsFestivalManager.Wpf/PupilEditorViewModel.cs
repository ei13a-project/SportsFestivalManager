using SportsFestivalManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportsFestivalManager.Wpf
{
    public class PupilEditorViewModel : ViewModel
    {
        public PersonEditorControlViewModel PersonViewModel { get; }
        private Pupil _pupil;

        public ICommand SaveButtonCommand { get; }

        public PupilEditorViewModel(Pupil pupil = null)
        {
            _pupil = pupil ?? new Pupil();
            PersonViewModel = new PersonEditorControlViewModel(_pupil);

            SaveButtonCommand = new RelayCommand(SaveButton, CanSave);
        }

        public void SaveButton()
        {
            PersonViewModel.SaveButton();
        }

        public bool CanSave()
        {
            return PersonViewModel.CanSave();
        }
    }
}