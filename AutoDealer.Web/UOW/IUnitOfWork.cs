using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoDealer.Services.Interfaces;

namespace AutoDealer.Web.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        ICarServices CarServices { get; }
        ICar_GalleryServices Car_GalleryServices { get; }
        IManufacturerServices ManufacturerServices { get; }
        IModelServices ModelServices { get; }
        ISubModelServices SubModelServices { get; }
        IOptionServices OptionServices { get; }
        IOption_CategoryServices Option_CategoryServices { get; }
        ICar_Selected_OptionServices Car_Selected_Option { get; }
    }
}
