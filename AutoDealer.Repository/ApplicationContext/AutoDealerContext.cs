using System.Data.Entity;
using AutoDealer.Data.Vehicle;

namespace AutoDealer.Repository.ApplicationContext
{
    public class AutoDealerContext:DbContext
    {
        public AutoDealerContext():base("name=autoDealerDbContext")
        {       
        }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Car_Gallery> CarGalleries { get; set; }

    }
}
