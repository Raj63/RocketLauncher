using System;
using Nasa.RocketLauncher.Common.Interfaces;
using Nasa.RocketLauncher.Business.Src.Interfaces;
using Nasa.RocketLauncher.Contract.DataContracts;
using System.Collections.Generic;

namespace Nasa.RocketLauncher.Application
{
    public class CommandCentre
    {
        private readonly IHelper _helper;
        private readonly IUserInteraction _userInteraction;
        private readonly INextGenCargoRocketWarehouse _cargoRocketWarehouse;

        public CommandCentre(IHelper helper, IUserInteraction userInteraction, 
            INextGenCargoRocketWarehouse CargoRocketWarehouse)
        {
            _helper = helper;
            _userInteraction = userInteraction;
            _cargoRocketWarehouse = CargoRocketWarehouse;

            Dashboard.InitializeDashboard(_helper, _userInteraction, _cargoRocketWarehouse);
        }

        public void Start()
        {
            int? action = null;
            Console.WriteLine("**********Welcome to Nasa Command centre**********");
            action = _helper.ProcessUserAction(Constants.ENTER_COMMAND, Constants.CREATE_ROCKET);

            if(!action.Abort())
            {

                string rocketName = _helper.ReadUserInputs(string.Format(Constants.ENTER_NAME, "Rocket"));
                string rocketDestination = _helper.ReadUserInputs(string.Format(Constants.ENTER_NAME, "Rocket Destination"));
                var rocket = _cargoRocketWarehouse.CreateRocket(rocketName, rocketDestination);

                while (true)
                {
                    int? option = _helper.ProcessUserAction(Constants.ENTER_COMMAND, Constants.OPTIONS);

                    if (option != null && option > 0 && option < 7)
                    {
                        Dashboard.Operation(option.Value, rocketName);

                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        _userInteraction.PrintMessage("Mission Abort!!");
                        break;
                    }
                }
            }
            else
            {
                _userInteraction.PrintMessage("Mission Abort!!");
            }

            Console.WriteLine("Press any Key to Kill");
            Console.ReadKey();
        }

        
    }
}
