using SEDC.Agency.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Agency.DL.EFDAL
{
    public class AgencyContext : DbContext
    {
        public AgencyContext() 
            : base(AppConfig.ConnectionStringName)
        {
        }

        public AgencyContext(string connectionString)
            : base(connectionString)
        { }

        public DbSet<Property> Properties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
