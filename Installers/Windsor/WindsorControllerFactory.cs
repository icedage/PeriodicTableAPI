using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace HostelBookers.Pricing.WebApi.Infrastructure.Windsor
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        readonly IWindsorContainer _container;
    

        public WindsorControllerFactory(IWindsorContainer container)
        {   
            _container = container;
        }

        public override void ReleaseController(IController controller)
        {
            _container.Kernel.ReleaseComponent(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            try
            {
                if (controllerType == null)
                {
                    throw new HttpException(404,
                        string.Format("The controller for path '{0}' could not be found.",
                        requestContext.HttpContext.Request.Path));
                }

                var controller = _container.Kernel.Resolve(controllerType) as Controller;

                // new code
                if (controller != null)
                {
                    controller.ActionInvoker = _container.Resolve<IActionInvoker>();
                }

                return (IController)_container.Kernel.Resolve(controllerType);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}