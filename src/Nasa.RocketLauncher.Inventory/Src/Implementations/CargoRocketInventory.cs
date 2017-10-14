using System.Collections.Generic;
using Nasa.RocketLauncher.Contract.DataContracts;
using Nasa.RocketLauncher.Inventory.Src.Interfaces;

namespace Nasa.RocketLauncher.Inventory.Src.Implementations
{
    public class CargoRocketInventory : ICargoRocketInventory
    {
        /// <summary>
        /// Store Rockets into the inventory
        /// </summary>
        /// <param name="rocket"></param>
        /// <returns></returns>
        public bool StoreRocket(CargoRocket rocket)
        {
            bool response = false;
            if (rocket != null && !string.IsNullOrWhiteSpace(rocket.Name) && Storage.Storage.CargoRockets != null)
            {
                Storage.Storage.CargoRockets.Add(rocket);
                response = true;
            }

            return response;
        }

        /// <summary>
        /// Gets the rocket from inventory
        /// </summary>
        /// <param name="rocketName"></param>
        /// <returns></returns>
        public CargoRocket GetRocket(string rocketName)
        {
            CargoRocket response = null;

            if (!string.IsNullOrWhiteSpace(rocketName) && Storage.Storage.CargoRockets != null && Storage.Storage.CargoRockets.Count > 0)
            {
                foreach(var rocket in Storage.Storage.CargoRockets)
                {
                    if(rocket != null && rocket.Name.Equals(rocketName))
                    {
                        response = rocket;
                        break;
                    }
                }
                
            }
            return response;
        }

        /// <summary>
        /// Scrap the rocket from inventory
        /// </summary>
        /// <param name="rocketName"></param>
        /// <returns></returns>
        public bool ScrapRocket(string rocketName)
        {
            bool response = false;
            if (!string.IsNullOrWhiteSpace(rocketName) && Storage.Storage.CargoRockets != null && Storage.Storage.CargoRockets.Count > 0)
            {
                CargoRocket rocket = GetRocket(rocketName);
                if(rocket != null)
                {
                    Storage.Storage.CargoRockets.Remove(rocket);
                    response = true;
                }
            }

            return response;
        }

        /// <summary>
        /// Load satellites to a rocket
        /// </summary>
        /// <param name="satellites"></param>
        /// <param name="rocketName"></param>
        /// <returns></returns>
        public bool LoadSatellites(List<Satellite> satellites, string rocketName)
        {
            bool response = false;
            if (!string.IsNullOrWhiteSpace(rocketName) && Storage.Storage.CargoRockets != null && Storage.Storage.CargoRockets.Count > 0)
            {
                foreach (var rocket in Storage.Storage.CargoRockets)
                {
                    if (rocket != null && rocket.Name.Equals(rocketName))
                    {
                        if(rocket.satellites == null)
                        {
                            rocket.satellites = new List<Satellite>();
                        }

                        rocket.satellites.AddRange(satellites);
                        response = true;
                        break;
                    }
                }

            }

            return response;
        }

        /// <summary>
        /// Unload input satellites from the rocket
        /// </summary>
        /// <param name="satellites"></param>
        /// <param name="rocketName"></param>
        /// <returns></returns>
        public bool UnloadSatellites(List<Satellite> satellites, string rocketName)
        {
            bool response = false;
            if (!string.IsNullOrWhiteSpace(rocketName) && Storage.Storage.CargoRockets != null && Storage.Storage.CargoRockets.Count > 0)
            {
                foreach (var rocket in Storage.Storage.CargoRockets)
                {
                    if (rocket != null && rocket.Name.Equals(rocketName))
                    {
                        if (rocket.satellites != null)
                        {
                            rocket.satellites.RemoveAll(satellite => satellites.Contains(satellite));
                            response = true;
                        }                        
                        break;
                    }
                }

            }

            return response;
        }

        /// <summary>
        /// Change destination of a rocket
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="rocketName"></param>
        /// <returns></returns>
        public CargoRocket ChangeDestination(string destination, string rocketName)
        {
            CargoRocket response = null;
            if (!string.IsNullOrWhiteSpace(rocketName) && Storage.Storage.CargoRockets != null && Storage.Storage.CargoRockets.Count > 0)
            {
                foreach (var rocket in Storage.Storage.CargoRockets)
                {
                    if (rocket != null && rocket.Name.Equals(rocketName))
                    {
                        if (rocket.satellites != null)
                        {
                            rocket.Destination = destination;
                            response = rocket;
                        }
                        break;
                    }
                }

            }

            return response;
        }

    }
}
