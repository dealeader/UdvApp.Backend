using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdvApp.Application.Common.Exceptions;
using UdvApp.Application.UserTasks.Commands.Create;
using UdvApp.Application.UserTasks.Commands.Delete;
using UdvApp.Tests.Common;

namespace UdvApp.Tests.UserTasks.Commands
{
    public class DeleteUserTaskCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteNoteCommandHandler_Success()
        {
            var handler = new DeleteUserTaskCommandHandler(Context);

            await handler.Handle(
                new DeleteUserTaskCommand
                {
                    Id = UdvAppContextFactory.UserTaskIdForDelete,
                    UserId = UdvAppContextFactory.UserAId,
                    FacultyId = UdvAppContextFactory.TestFacultyId
                }, CancellationToken.None);

            Assert.Null(
                await Context.UserTasks.SingleOrDefaultAsync(usertask =>
                    usertask.Id == UdvAppContextFactory.UserTaskIdForDelete));
        }

        [Fact]
        public async Task DeleteNoteCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteUserTaskCommandHandler(Context);

            await handler.Handle(
                new DeleteUserTaskCommand
                {
                    Id = UdvAppContextFactory.UserTaskIdForDelete,
                    UserId = UdvAppContextFactory.UserAId,
                    FacultyId = UdvAppContextFactory.TestFacultyId
                }, CancellationToken.None);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(new DeleteUserTaskCommand
                {
                    FacultyId = UdvAppContextFactory.TestFacultyId,
                    Id = Guid.NewGuid(),
                    UserId = UdvAppContextFactory.UserAId
                }, CancellationToken.None));
        }

        [Fact]
        public async Task DeleteNoteCommandHandler_FailOnWrongUserId()
        {
            var deleteHandler = new DeleteUserTaskCommandHandler(Context);
            var createHandler = new CreateUserTaskCommandHandler(Context);

            var userTaskId = await createHandler.Handle(
                new CreateUserTaskCommand
                {
                    Task = "TestTask",
                    Status = "TestStatus",
                    UserId = UdvAppContextFactory.UserAId
                }, CancellationToken.None);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(new DeleteUserTaskCommand
                {
                    FacultyId = UdvAppContextFactory.TestFacultyId,
                    Id = userTaskId,
                    UserId = UdvAppContextFactory.UserBId
                }, CancellationToken.None));
        }
    }
}
