using MasterCommands.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterCommands.Data
{
    public class MasterCommandsContext : DbContext
    {
        public MasterCommandsContext(DbContextOptions<MasterCommandsContext> opt) : base(opt)
        {

        }

        public DbSet<Command> Commands { get; set; }
    }
}
