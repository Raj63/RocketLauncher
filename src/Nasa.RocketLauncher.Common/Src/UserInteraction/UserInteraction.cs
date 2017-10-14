using System;
using System.Collections.Generic;
using Nasa.RocketLauncher.Common.Interfaces;

namespace Nasa.RocketLauncher.Common.UserInteraction
{
    public class UserInteraction : IUserInteraction
    {
        public void PrintCommands(List<string> commandList)
        {
            int counter = 1;
            foreach (var command in commandList)
            {
                Console.WriteLine("{0}. {1}", counter++, command);
            }
        }

        public void PrintMessage(string msg)
        {
            Console.Clear();
            Console.WriteLine("\n{0}\n", msg);
        }

        public string ReadCommand()
        {
            return Console.ReadLine();
        }
    }
}
