using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFestivalManager.Data
{
    internal class SportsFestivalManagerDbConfiguration : DbConfiguration
    {
        public SportsFestivalManagerDbConfiguration()
        {
            SetProviderServices(nameof(System.Data.SqlClient), SqlProviderServices.Instance);
        }
    }
}
