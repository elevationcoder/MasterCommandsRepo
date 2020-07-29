using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MasterCommands.Data;
using MasterCommands.DTOs;
using MasterCommands.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MasterCommands.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly IMasterCommandsRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(IMasterCommandsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/<CommandsController>
        [HttpGet]
        public ActionResult<IEnumerable<MasterCommandsReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<MasterCommandsReadDto>>(commandItems));
            
        }

        // GET api/<CommandsController>/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<MasterCommandsReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            if(commandItem != null)
            {
                return Ok(_mapper.Map<MasterCommandsReadDto>(commandItem));
            }
            return NotFound();
        }

        // POST api/<CommandsController>
        [HttpPost]
        public ActionResult<MasterCommandsReadDto> CreateCommand(MasterCommandsCreateDto masterCommandsCreateDto)
        {
            var commandModel = _mapper.Map<Command>(masterCommandsCreateDto);

            _repository.CreateCommand(commandModel);

            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<MasterCommandsReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }

        // PUT api/<CommandsController>/5
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, MasterCommandsUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);

            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PatchCommandUpdate(int id, JsonPatchDocument<MasterCommandsUpdateDto> patchCommand)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            var commandToPatch = _mapper.Map<MasterCommandsUpdateDto>(commandModelFromRepo);

            patchCommand.ApplyTo(commandToPatch, ModelState);
            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/<CommandsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
