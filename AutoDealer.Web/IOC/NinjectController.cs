using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoDealer.Repository.ApplicationContext;
using AutoDealer.Web.UOW;
using Ninject;

namespace AutoDealer.Web.IOC
{
    public class NinjectController : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectController()
        {
            ninjectKernel = new StandardKernel();

            Bind();
        }

        private void Bind()
        {
            ninjectKernel.Bind<AutoDealerContext>().To<AutoDealerContext>();
            ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>();
       
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, "not found");
            }

            return (IController)ninjectKernel.Get(controllerType);
        }
    }
}