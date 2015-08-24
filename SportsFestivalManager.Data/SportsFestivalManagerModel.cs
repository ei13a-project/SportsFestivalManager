using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;

namespace SportsFestivalManager.Data
{
    [DbConfigurationType(typeof(SportsFestivalManagerDbConfiguration))]
    public class SportsFestivalManagerModel : DbContext
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

        public virtual DbSet<Address> Addresses { get; }
        public virtual DbSet<Category> Categories { get; }
        public virtual DbSet<Class> Classes { get; }
        public virtual DbSet<Discipline> Disciplines { get; }
        public virtual DbSet<Person> People { get; }

        public SportsFestivalManagerModel()
            : this(DefaultConnectionString)
        {
        }
        public SportsFestivalManagerModel(string connectionStringOrName)
            : base(connectionStringOrName)
        {
            Addresses = Set<Address>();
            Categories = Set<Category>();
            Classes = Set<Class>();
            Disciplines = Set<Discipline>();
            People = Set<Person>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
