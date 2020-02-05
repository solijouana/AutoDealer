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
            if (!string.IsNullOrEmpty(filter.Filter))
            {
                queryable = queryable.Where(c =>
                    c.Manufacturers.ManufacturerName.Contains(filter.Filter) ||
                    c.Model.ModelTitle.Contains(filter.Filter));
            }

            return queryable;
        }

        #endregion
    }
}
