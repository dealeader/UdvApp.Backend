using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdvApp.Api.Models;
using UdvApp.Api.Models.Faculty;
using UdvApp.Application.Faculties.Commands.Create;
using UdvApp.Application.Faculties.Commands.Delete;
using UdvApp.Application.Faculties.Commands.Update;
using UdvApp.Application.Faculties.Queries.GetFacultyDetailsQuery;
using UdvApp.Application.Faculties.Queries.GetFacultyList;

namespace UdvApp.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FacultyController : BaseController
    {
        private readonly IMapper _mapper;

        public FacultyController(IMapper mapper) =>
            _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<FacultyListVm>> GetAll()
        {
            var query = new GetFacultyListQuery
            {
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FacultyDetailsVm>> Get(Guid id)
        {
            var query = new GetFacultyDetailsQuery
            {
                Id = id   
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateFacultyDto createUserTaskDto)
        {
            var command = _mapper.Map<CreateFacultyCommand>(createUserTaskDto);

            command.UserId = UserId;

            var noteId = await Mediator.Send(command);

            return Ok(noteId);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateUserTaskDto updateUserTaskDto)
        {
            var command = _mapper.Map<UpdateFacultyCommand>(updateUserTaskDto);

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var command = new DeleteFacultyCommand
            {
                Id = id,
            };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
