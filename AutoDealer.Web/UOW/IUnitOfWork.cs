using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoDealer.Services.Interfaces;

namespace AutoDealer.Web.UOW
{
    interface IUnitOfWork:IDisposable
    {
        ICarServices CarServices { get; }
        ICar_GalleryServices Car_GalleryServices { get; }   
    }
}
