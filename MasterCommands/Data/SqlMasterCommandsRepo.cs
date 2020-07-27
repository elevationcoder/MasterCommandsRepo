using MasterCommands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterCommands.Data
{
    public class SqlMasterCommandsRepo : IMasterCommandsRepo
    {
        private readonly MasterCommandsContext _context;

        public SqlMasterCommandsRepo(MasterCommandsContext context)
        {
            _context = context;
        }
        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == id);
        }
    }
}
