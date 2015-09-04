using SportsFestivalManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportsFestivalManager.Wpf
{
    public class PersonDataViewModel : ViewModel
    {
        private Person _person;

        public string FirstName
        {
            get { return GetValue(() => FirstName); }
            set { SetValue(() => FirstName, value); }
        }
        public string LastName
        {
            get { return GetValue(() => LastName); }
            set { SetValue(() => LastName, value); }
        }
        public DateTime BirthDate
        {
            get { return GetValue(() => BirthDate); }
            set { SetValue(() => BirthDate, value); }
        }
        public string Location
        {
            get { return GetValue(() => Location); }
            set { SetValue(() => Location, value); }
        }
        public string PostalCode
        {
            get { return GetValue(() => PostalCode); }
            set { SetValue(() => PostalCode, value); }
        }
        public string Street
        {
            get { return GetValue(() => Street); }
            set { SetValue(() => Street, value); }
        }
        public string HouseNumber
        {
            get { return GetValue(() => HouseNumber); }
            set { SetValue(() => HouseNumber, value); }
        }
        public string Class
        {
            get { return GetValue(() => Class); }
            set { SetValue(() => Class, value); }
        }
        public string GenderString
        {
            get { return GetValue(() => GenderString); }
            set { SetValue(() => GenderString, value); }
        }
        public int Age
        {
            get
            {
                var age = DateTime.Today.Year - BirthDate.Year;
                if (BirthDate > DateTime.Today.AddYears(-age))
                    age--;
                return age;
            }
        }

        public ICommand SaveCommand { get; }

        public PersonDataViewModel(Person person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));
            if (person.Address == null)
                person.Address = new Address();
            _person = person;

            SaveCommand = new RelayCommand(Save, CanSave);
        }

        public virtual void Save()
        {
            _person.FirstName = FirstName;
            _person.LastName = LastName;
            _person.BirthDate = BirthDate;
            _person.Class = Class;
            _person.Address.Location = Location;
            _person.Address.PostalCode = PostalCode;
            _person.Address.Street = Street;
            _person.Address.HouseNumber = HouseNumber;
            _person.Gender = StringToGender(GenderString);
        }

        public virtual bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(FirstName)
                && !string.IsNullOrWhiteSpace(LastName)
                && !string.IsNullOrWhiteSpace(Class)
                && !string.IsNullOrWhiteSpace(Location)
                && !string.IsNullOrWhiteSpace(PostalCode)
                && !string.IsNullOrWhiteSpace(Street)
                && !string.IsNullOrWhiteSpace(HouseNumber)
                && !string.IsNullOrWhiteSpace(GenderString)
                && (Age > 0 && Age < 100);
        }

        private static Gender StringToGender(string genderString)
        {
            bool gender = genderString.Contains("Männlich");
            if (genderString.Contains("Männlich"))
                return Gender.Male;
            else if (genderString.Contains("Weiblich"))
                return Gender.Female;
            else
                throw new ArgumentException();
        }
    }
}
