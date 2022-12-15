using MediatR;
using Microsoft.EntityFrameworkCore;
using UdvApp.Application.Common.Exceptions;
using UdvApp.Application.Interfaces;
using UdvApp.Domain;

namespace UdvApp.Application.UserTasks.Commands.Update
{
    public class UpdateUserTaskCommandHandler : IRequestHandler<UpdateUserTaskCommand>
    {
        private readonly IUdvAppDbContext _dbContext;

        public UpdateUserTaskCommandHandler(IUdvAppDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateUserTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.UserTasks.FirstOrDefaultAsync(task => task.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId || entity.FacultyId != request.FacultyId)
            {
                throw new NotFoundException(nameof(UserTask), request.Id);
            }

            entity.Status = request.Status;
            entity.Task = request.Task;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
