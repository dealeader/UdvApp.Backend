using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdvApp.Application.UserTasks.Commands.Create;
using UdvApp.Tests.Common;

namespace UdvApp.Tests.UserTasks.Commands
{
    public class CreateUserTaskCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateNoteCommandHandler_Success()
        {
            var handler = new CreateUserTaskCommandHandler(Context);
            var userTaskTask = "test task name";
            var userTaskStatus = "test open";

            var userTaskId = await handler.Handle(
                new CreateUserTaskCommand
                {
                    Task = userTaskTask,
                    Status = userTaskStatus,
                    UserId = UdvAppContextFactory.UserAId
                }, CancellationToken.None);

            Assert.NotNull(
                await Context.UserTasks.SingleOrDefaultAsync(usertask =>
                    usertask.Id == userTaskId
                    && usertask.Task == userTaskTask
                    && usertask.Status == userTaskStatus));
        }
    }
}
