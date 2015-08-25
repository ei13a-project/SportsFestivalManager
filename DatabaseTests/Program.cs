using SportsFestivalManager.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTests
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Environment.CurrentDirectory);

            using (var connection = new SportsFestivalManagerContext())
            {
                try
                {
                    var address1 = new Address("Location1", "123", "Street1", "123");
                    connection.Addresses.Add(address1);
                    var address2 = new Address("Location2", "321", "Street2", "321");
                    connection.Addresses.Add(address2);

                    var teacher = new Teacher()
                    {
                        Address = address1,
                        BirthDate = DateTime.Now,
                        FirstName = "FirstName",
                        LastName = "LastName"
                    };
                    connection.People.Add(teacher);

                    var @class = new Class()
                    {
                        Name = "class",
                        Teacher = teacher
                    };
                    connection.Classes.Add(@class);

                    var pupil = new Pupil()
                    {
                        Address = address1,
                        FirstName = "Hans",
                        LastName = "Wurst",
                        BirthDate = DateTime.Now,
                        Class = @class
                    };
                    connection.People.Add(pupil);

                    connection.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            using (var connection = new SportsFestivalManagerContext())
            {
                var addresses = connection.Addresses.ToArray();
                var pupils = connection.People.OfType<Pupil>().ToArray();
                var teacher = connection.People.OfType<Teacher>().ToArray();
                var classes = connection.Classes.ToArray();
                var disciplines = connection.Disciplines.ToArray();
                var achievments = connection.Achievements.ToArray();
                var festivals = connection.Festivals.ToArray();
            }
        }
    }
}
