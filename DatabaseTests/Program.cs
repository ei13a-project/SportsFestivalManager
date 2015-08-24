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

            using (var connection = new SportsFestivalManagerModel())
            {
                try
                {
                    var address = new Address()
                    {
                        Location = "Location1",
                        HouseNumber = "123",
                        PostalCode = "123",
                        Street = "Street1",
                    };
                    connection.Addresses.Add(address);

                    var teacher = new Teacher()
                    {
                        Address = address,
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
                        Address = address,
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
            using (var connection = new SportsFestivalManagerModel())
            {
                var addresses = connection.Addresses.ToArray();
                var people = connection.People.ToArray();
                var pupils = connection.People.OfType<Pupil>().ToArray();
                var teacher = connection.People.OfType<Teacher>().ToArray();
                var classes = connection.Classes.ToArray();
                var disciplines = connection.Disciplines.ToArray();
            }
        }
    }
}
