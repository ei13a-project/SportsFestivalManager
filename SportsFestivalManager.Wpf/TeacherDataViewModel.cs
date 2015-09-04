using SportsFestivalManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportsFestivalManager.Wpf
{
    public class TeacherDataViewModel : PersonDataViewModel
    {
        private Teacher _teacher;

        public TeacherDataViewModel(Teacher teacher = null)
            : base(teacher = teacher ?? new Teacher())
        {
            _teacher = teacher;
        }

        public override bool CanSave()
        {
            return base.CanSave();
        }
        public override void Save()
        {
            base.Save();
        }
    }
}