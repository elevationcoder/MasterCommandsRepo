using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MasterCommands.Data;
using MasterCommands.DTOs;
using MasterCommands.Models;
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
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(commandItems);
            
        }

        // GET api/<CommandsController>/{id}
        [HttpGet("{id}")]
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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CommandsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommandsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
