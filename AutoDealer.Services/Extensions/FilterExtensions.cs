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

        #endregion
    }
}
