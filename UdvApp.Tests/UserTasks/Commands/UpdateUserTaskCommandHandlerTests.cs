using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdvApp.Application.Common.Exceptions;
using UdvApp.Application.UserTasks.Commands.Create;
using UdvApp.Application.UserTasks.Commands.Delete;
using UdvApp.Application.UserTasks.Commands.Update;
using UdvApp.Tests.Common;

namespace UdvApp.Tests.UserTasks.Commands
{
    public class UpdateUserTaskCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateNoteCommandHandler_Success()
        {
            var handler = new UpdateUserTaskCommandHandler(Context);
            var newUserTaskTask = "test task name update";
            var newUserTaskStatus = "test open update";

            var userTaskId = await handler.Handle(
                new UpdateUserTaskCommand
                {
                    Id = UdvAppContextFactory.UserTaskIdForUpdate,
                    UserId = UdvAppContextFactory.UserBId,
                    FacultyId = UdvAppContextFactory.TestFacultyId,
                    Status = newUserTaskStatus,
                    Task = newUserTaskTask
                }, CancellationToken.None);

            Assert.NotNull(
                await Context.UserTasks.SingleOrDefaultAsync(usertask =>
                    usertask.Id == UdvAppContextFactory.UserTaskIdForUpdate
                    && usertask.Task == newUserTaskTask
                    && usertask.Status == newUserTaskStatus));
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOnWrongId()
        {
            var handler = new UpdateUserTaskCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(new UpdateUserTaskCommand
                {
                    FacultyId = UdvAppContextFactory.TestFacultyId,
                    Id = Guid.NewGuid(),
                    UserId = UdvAppContextFactory.UserAId
                }, CancellationToken.None));
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOnWrongUserId()
        {
            var handler = new UpdateUserTaskCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(new UpdateUserTaskCommand
                {
                    Id = UdvAppContextFactory.UserTaskIdForUpdate,
                    UserId = UdvAppContextFactory.UserAId,
                    FacultyId = UdvAppContextFactory.TestFacultyId,

                }, CancellationToken.None));
        }
    }
}
