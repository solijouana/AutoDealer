using System.Linq;
using AutoDealer.Data.Vehicle;
using AutoDealer.Services.DTO.Advertise;

namespace AutoDealer.Services.Extensions
{
    public static class FilterExtensions
    {
        #region Cars

        public static IQueryable<Car> SetCarsFilter(this IQueryable<Car> queryable, AdminAdvertiseDto filter)
        {
            if (!string.IsNullOrEmpty(filter.FilterName))
            {
                queryable = queryable.Where(s => s.Manufacturers.ManufacturerName.Contains(filter.FilterName)||s.Model.ModelTitle.Contains(filter.FilterName)||s.SubModel.SubModelTitle.Contains(filter.FilterName));
            }

            return queryable;
        }

        public static IQueryable<Car> SetCatalogCarsFilter(this IQueryable<Car> queryable, AdvertiseCatalogDto filter)
        {
            if (filter.ManufacturerId!=0)
            {
                queryable = queryable.Where(m => m.ManufacturerId == filter.ManufacturerId);
            }

            if (filter.ModelId != 0)
            {
                queryable = queryable.Where(m => m.ModelId == filter.ModelId);
            }

            if (filter.FromPrice != 0)
            {
                queryable = queryable.Where(m => m.Price >= filter.FromPrice);
            }

            if (filter.ToPrice != 0)
            {
                queryable = queryable.Where(m => m.Price <= filter.ToPrice);
            }

            if (filter.FromYear != 0 )
            {
                queryable = queryable.Where(m => m.ProductionDate >= filter.FromYear);
            }

            if (filter.ToYear != 0)
            {
                queryable = queryable.Where(m => m.ProductionDate <= filter.ToYear);
            }

            return queryable;
        }

        #endregion
    }
}
