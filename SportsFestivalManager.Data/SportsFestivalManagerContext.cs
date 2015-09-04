using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;

namespace SportsFestivalManager.Data
{
    [DbConfigurationType(typeof(SportsFestivalManagerDbConfiguration))]
    public class SportsFestivalManagerContext : DbContext
    {
        public static string DefaultConnectionString
        {
            get
            {
                return new SqlConnectionStringBuilder()
                {
                    DataSource = @"(LocalDB)\MSSQLLocalDB",
                    AttachDBFilename = @"|DataDirectory|\SportsFestivalManager.mdf",
                    IntegratedSecurity = true,
                    MultipleActiveResultSets = true
                }.ToString();
            }
        }

        public virtual IDbSet<Address> Addresses { get; }
        public virtual IDbSet<Category> Categories { get; }
        public virtual IDbSet<Discipline> Disciplines { get; }
        public virtual IDbSet<Person> People { get; }
        public virtual IDbSet<Achievement> Achievements { get; }
        public virtual IDbSet<Festival> Festivals { get; }

        public SportsFestivalManagerContext()
            : this(DefaultConnectionString)
        {
        }
        public SportsFestivalManagerContext(string connectionStringOrName)
            : base(connectionStringOrName)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SportsFestivalManagerContext>());

            Addresses = Set<Address>();
            Categories = Set<Category>();
            Disciplines = Set<Discipline>();
            People = Set<Person>();
            Achievements = Set<Achievement>();
            Festivals = Set<Festival>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
