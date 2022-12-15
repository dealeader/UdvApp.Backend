using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdvApp.Api.Models;
using UdvApp.Application.UserTasks.Commands.Create;
using UdvApp.Application.UserTasks.Commands.Delete;
using UdvApp.Application.UserTasks.Commands.Update;
using UdvApp.Application.UserTasks.Queries.GetUserTaskDetailsQuery;
using UdvApp.Application.UserTasks.Queries.GetUserTaskList;

namespace UdvApp.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserTaskController : BaseController
    {
        private readonly IMapper _mapper;

        public UserTaskController(IMapper mapper) =>
            _mapper = mapper;

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserTaskListVm>> GetAll()
        {
            var query = new GetUserTaskListQuery
            {
                UserId = UserId
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserTaskDetailsVm>> Get(Guid id)
        {
            var query = new GetUserTaskDetailsQuery
            {
                UserId = UserId,
                Id = id,
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserTaskDto createUserTaskDto)
        {
            var command = _mapper.Map<CreateUserTaskCommand>(createUserTaskDto);

            command.UserId = UserId;
            
            var noteId = await Mediator.Send(command);

            return Ok(noteId);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateUserTaskDto updateUserTaskDto)
        {
            var command = _mapper.Map<UpdateUserTaskCommand>(updateUserTaskDto);

            command.UserId = UserId;

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var command = new DeleteUserTaskCommand
            {
                Id = id,
                UserId = UserId
            };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
