using System.Collections.Generic;
using AutoDealer.Data.Vehicle;
using AutoDealer.Services.DTO.Paging;

namespace AutoDealer.Services.DTO.Advertise
{
    public class AdminAdvertiseDto : BasePaging
    {
        public string FilterName { get; set; }
        public List<Car> Cars { get; set; }

        public AdminAdvertiseDto SetPaggingItem(BasePaging paging)
        {
            PageId = paging.PageId;
            ActivePage = paging.ActivePage;
            PageCount = paging.PageCount;
            StartPage = paging.StartPage;
            EndPage = paging.EndPage;
            TakeEntity = paging.TakeEntity;
            SkipEntity = paging.SkipEntity;

            return this;
        }

        public AdminAdvertiseDto SetCars(List<Car> cars)
        {
            Cars = cars;

            return this;
        }
    }
}
