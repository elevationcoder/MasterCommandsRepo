using AutoMapper;
using MasterCommands.DTOs;
using MasterCommands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterCommands.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, MasterCommandsReadDto>();
            CreateMap<MasterCommandsCreateDto, Command>();
            CreateMap<MasterCommandsUpdateDto, Command>();
        }
    }
}
