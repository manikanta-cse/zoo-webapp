using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Zoo.Services.Models;

namespace Zoo.Services.Data
{
    public class ZooContext:DbContext
    {
        public ZooContext()
            : base("ZooContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer<ZooContext>(new DropCreateDatabaseIfModelChanges<ZooContext>());
        }

        public DbSet<Species> Species { get; set; }
        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
