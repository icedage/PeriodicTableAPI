using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PeriodicTableAPI.Presenters.Classes;
using PeriodicTableAPI.Presenters.Interfaces;
using PeriodicTableAPI.Services.Installers;
using PeriodicTableAPI.Services.Services.Classes;
using PeriodicTableAPI.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeriodicTableAPI.Installers
{
    public class PresentationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(new ServicesInstaller());
            
            container.Register(
                Component.For<IPeriodicDetailsPresenter>()
                         .ImplementedBy<PeriodicDetailsPresenter>()
                         .LifeStyle.Transient);
            //container.Register(
            //    Component.For<IPeriodicTableService>()
            //             .ImplementedBy<PeriodicTableService>()
            //             .LifeStyle.Transient);
          }
    }
}