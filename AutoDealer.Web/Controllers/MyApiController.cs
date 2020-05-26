using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoDealer.Repository.ApplicationContext;
using AutoDealer.Web.UOW;
using Newtonsoft.Json;

namespace AutoDealer.Web.Controllers
{
    public class MyApiController : ApiController
    {
        private IUnitOfWork _unitOfWork=new UnitOfWork(new AutoDealerContext());
        public IHttpActionResult Get()
        {
            return Ok(_unitOfWork.CarServices.GetAllCars().ToList());
        }
    }
}
