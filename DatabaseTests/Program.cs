using SportsFestivalManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTests
{
    class Program
    {
        static void Main(string[] args)
        {
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

                    var pupil = new Pupil()
                    {
                        Address = address,
                        FirstName = "Hans",
                        LastName = "Wurst",
                        BirthDate = DateTime.Now,
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
