using SimpleInjector;
using Nasa.RocketLauncher.Common.Interfaces;
using Nasa.RocketLauncher.Inventory.Src.Interfaces;
using Nasa.RocketLauncher.Inventory.Src.Implementations;
using Nasa.RocketLauncher.Business.Src.Interfaces;
using Nasa.RocketLauncher.Business.Src.Implementations;

namespace Nasa.RocketLauncher.Common.Src
{
    public static class DependencyInjection
    {
        public static Container Configure()
        {
            var container = new Container();

            container.Register<IHelper, Helper.Helper>();
            container.Register<IUserInteraction, UserInteraction.UserInteraction>();
            container.Register<ICargoRocketInventory, CargoRocketInventory>();
            container.Register<INonCargoRocketInventory, NonCargoRocketInventory>();
            container.Register<ICargoRocketWarehouse, CargoRocketWarehouse>();
            //container.Register<INonCargoRocketWarehouse, NonCargoRocketWarehouse>();
            container.Register<INextGenCargoRocketWarehouse, NextGenCargoRocketWarehouse>();
            //container.Verify();

            return container;
        }
    }
}
