﻿using System.Collections.Generic;
using AutoDealer.Data.Vehicle;
using AutoDealer.Services.DTO.Paging;

namespace AutoDealer.Services.DTO.Advertise
{
   public class AdvertiseCatalogDto:BasePaging
    {
        public string Filter { get; set; }
        public List<Car> Cars { get; set; }
        public int ManufacturerId { get; set; }
        public int ModelId { get; set; }
        public string ManufacturerName { get; set; }
       public AdvertiseCatalogDto SetPagging(BasePaging paging)
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

        public AdvertiseCatalogDto SetCar(List<Car> cars)
        {
            Cars = cars;

            return this;
        }
    }
}