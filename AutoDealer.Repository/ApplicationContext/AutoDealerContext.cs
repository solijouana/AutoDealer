using System.Data.Entity;
using AutoDealer.Data.Vehicle;

namespace AutoDealer.Repository.ApplicationContext
{
    public class AutoDealerContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Car_Gallery> CarGalleries { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

    }
}
