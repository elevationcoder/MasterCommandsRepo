using MasterCommands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterCommands.Data
{
    public class MockMasterCommandsRepo : IMasterCommandsRepo { 
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
               new Command{Id=0, HowTo="Boil an egg", Line="Boil water", Platform="Kettle and Pan"},
               new Command{Id=1, HowTo="Mow lawn", Line="Start mower", Platform="Lawn Mower"},
               new Command{Id=2, HowTo="Run", Line="Take long strides at a fast pace", Platform="Sidewalk"}
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle and Pan" };
        }
    }
}
