using System.Linq;
using AutoDealer.Services.DTO.Paging;

namespace AutoDealer.Services.Extensions
{
    public static class PagingExtension
    {
        public static IQueryable<T> Paging<T>(this IQueryable<T> queryable, BasePaging pager)
        {
            return queryable.Skip(pager.SkipEntity).Take(pager.TakeEntity);
        }
    }
}
